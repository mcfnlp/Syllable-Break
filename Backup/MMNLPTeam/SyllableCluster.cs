using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MMNLPTeam
{
    public class SyllableCluster
    {
        private static char breaker = ' ';

        /// <summary>
        /// Line Breaker
        /// </summary>
        /// <param name="st"></param>
        /// <param name="breaker"></param>
        /// <returns></returns>

        private string clusterpattern()
        {
            string SP = "([\u0028\u2018\u201C\u007b\u005b])?";
            string P = "([\u005d\u104A\u104B\u0029\u002d\u002e\u007d\u2019\u201d\u0027\u0022]){0,2}";
            string Man = SP + "\u101A\u1031\u102C\u1000\u103A\u103B\u102C\u1038" + P;
            string Me = SP + "\u1000\u103B\u103D\u1014\u103A\u102F\u1015\u103A" + P;
            string GSa = "\u103F";

            string M = "\u103B(\u103D(\u103E)?|\u103E)?|\u103C(\u103D(\u103E)?|\u103E)?|\u103D(\u103E)?|\u103E";
            string VA = "\u1031(\u102B|\u102C)\u103A";
            string V = "\u1031(\u102B|\u102C)?|\u102D(\u102F|\u1036)?|\u102B|\u102C|\u102E|\u102F(\u1036)?|\u1030|\u1032|\u1036";
            string F = "[\u1000-\u1021](\u103A(\u1039)?|\u1039)";
            string FF = "[\u1000-\u1021](" + M + ")?(\u103A)";
            string T = "\u1037|\u1038";
            string D = SP + "([\u1040-\u1049](\\.([\u1040-\u1049])+)*)+" + P;

            string loop1 = "(?<Final>" + F + ")(?<T>" + T + ")?(" + FF + ")*";
            string loop2 = "((?<VA>" + VA + ")(?<T>" + T + ")?|(?<V>" + V + ")(" + loop1 + "|(?<T>" + T + "))?)(" + FF + ")*";

            string loopsa = "(?<Gsa>" + GSa + ")((?<M>" + M + ")(" + loop2 + "|" + loop1 + ")?|" + loop2 + "|" + loop1 + "|\u1039)?";
            string floop = "((?<Final>" + F + ")(?<T>" + T + ")?(" + FF + ")*|" + loopsa + ")";
            string vloop = "((?<VA>" + VA + ")(?<T>" + T + ")?|(?<V>" + V + ")(" + floop + "|(?<T>" + T + "))?)(" + FF + ")*";

            string syllablepattern = SP + "(?<ID>\u104C|\u104D|\u104E\u1004\u103A\u1038|\u104F)" + P + "|" + SP + "(?<IV>[\u1023-\u102A])((?<T>" + T + ")|" + floop + ")?" + P + "|" + D + "|" + Man + "|" + Me + "|" + SP + "(?<C>[\u1000-\u1021])((?<M>" + M + ")(" + vloop + "|" + floop + ")?|" + vloop + "|" + floop + "|\u1039)?" + P;
            return syllablepattern;
        }


        public string ClusterBreaker(string input)   //line breaker
        {
            breaker = ' ';
            return ClusterBreaker(input, breaker);
        }

        public string ClusterBreaker(string input, char bsign)   //line breaker
        {
            breaker = bsign;
            string output;

            Regex re = new Regex(clusterpattern());

            output = re.Replace(input, new MatchEvaluator(insertbreak4ortho));

            return output;
        }

        /// <summary>
        /// Orthographic Breaker
        /// </summary>
        /// <param name="st"></param>
        /// <param name="breaker"></param>
        /// <returns></returns>

        private string orthopattern()
        {
            string Man = "\u101A\u1031\u102C\u1000\u103A\u103B\u102C\u1038";
            string Me = "\u1000\u103B\u103D\u1014\u103A\u102F\u1015\u103A";
            string GSa = "\u103F";

            string M = "\u103B(\u103D(\u103E)?|\u103E)?|\u103C(\u103D(\u103E)?|\u103E)?|\u103D(\u103E)?|\u103E";
            string VA = "\u1031(\u102B|\u102C)\u103A";
            string V = "\u1031(\u102B|\u102C)?|\u102D(\u102F|\u1036)?|\u102B|\u102C|\u102E|\u102F(\u1036)?|\u1030|\u1032|\u1036";
            string F = "[\u1000-\u1021](\u103A(\u1039)?|\u1039)";
            string FF = "[\u1000-\u1021](" + M + ")?(\u103A)";
            string T = "\u1037|\u1038";
            string D = "([\u1040-\u1049](\\.([\u1040-\u1049])+)*)+";

            string loop1 = "(?<Final>" + F + ")(?<T>" + T + ")?(" + FF + ")*";
            string loop2 = "((?<VA>" + VA + ")(?<T>" + T + ")?|(?<V>" + V + ")(" + loop1 + "|(?<T>" + T + "))?)(" + FF + ")*";

            string loopsa = "(?<Gsa>" + GSa + ")((?<M>" + M + ")(" + loop2 + "|" + loop1 + ")?|" + loop2 + "|" + loop1 + "|\u1039)?";
            string floop = "((?<Final>" + F + ")(?<T>" + T + ")?(" + FF + ")*|" + loopsa + ")";
            string vloop = "((?<VA>" + VA + ")(?<T>" + T + ")?|(?<V>" + V + ")(" + floop + "|(?<T>" + T + "))?)(" + FF + ")*";

            string syllablepattern = "(?<ID>\u104C|\u104D|\u104E\u1004\u103A\u1038|\u104F)|(?<IV>[\u1023-\u102A])((?<T>" + T + ")|" + floop + ")?|" + D + "|" + Man + "|" + Me + "|(?<C>[\u1000-\u1021])((?<M>" + M + ")(" + vloop + "|" + floop + ")?|" + vloop + "|" + floop + "|\u1039)?";
            return syllablepattern;
        }

        private string insertbreak4ortho(Match m)
        {
            string temp = m.Value.ToString();
            if (temp[temp.Length - 1].Equals('\u1039') | temp[temp.Length - 1].Equals('\u002d') | temp[temp.Length - 1].Equals('\u002e')) temp = temp;
            else
            {
                if (breaker == ' ') temp = temp + '\u200B';
                else temp = temp + breaker;
            }
            return temp;
        }

        public int GetOrthoCount(string input)
        {
            string temp = null;
            Regex re = new Regex(orthopattern());
            Match m = re.Match(input);
            int i = 0;
            while (m.Success)
            {
                temp = m.Value.ToString();
                if (temp[temp.Length - 1].Equals('\u1039') | temp[temp.Length - 1].Equals('\u002d') | temp[temp.Length - 1].Equals('\u002e')) i = i;
                else i++;
                m = m.NextMatch();
            }
            return i;
        }

        public string OrthographicBreaker(string input)
        {
            breaker = ' ';
            return OrthographicBreaker(input, breaker);
        }

        public string OrthographicBreaker(string input, char bsign)
        {
            breaker = bsign;

            string output = null;

            Regex re = new Regex(orthopattern());

            output = re.Replace(input, new MatchEvaluator(insertbreak4ortho));

            return output;

        }

        public string[] GetOrthoArray(string input)
        {
            string temp = null;
            Regex re = new Regex(orthopattern());
            Match m = re.Match(input);
            string[] pc = new string[GetOrthoCount(input)];
            int i = 0;
            while (m.Success)
            {
                temp = m.Value.ToString();
                if (temp[temp.Length - 1].Equals('\u1039') | temp[temp.Length - 1].Equals('\u002d') | temp[temp.Length - 1].Equals('\u002e')) { pc[i] = pc[i] + temp; }
                else
                {
                    pc[i] = pc[i] + temp;
                    i++;
                }
                m = m.NextMatch();
            }
            return pc;
        }


        /// <summary>
        /// Phonological Syllable Breaker for display
        /// </summary>
        /// <param name="st">String to break</param>
        /// <param name="breaker">break sign (v= | , i=ZWSP ) </param>
        /// <returns>string</returns>
        /// 

        private string phonopattern()
        {
            string awl = "\u1029\u1031\u102C\u1004\u103A\u1038";
            string aone = "\u1025\u102F\u1036";
            string au = "\u1025\u1030\u1038";

            string M = "\u103B(\u103D(\u103E)?|\u103E)?|\u103C(\u103D(\u103E)?|\u103E)?|\u103D(\u103E)?|\u103E";
            string V = "\u1031(\u102B(\u103A)?|\u102C(\u103A)?)?|\u102D(\u102F|\u1036)?|\u102B|\u102C|\u102E|\u102F(\u1036)?|\u1030|\u1032|\u1036";
            string F = "[\u1000-\u1021](\u103A|\u1039)";
            string T = "\u1037|\u1038";

            string loop1 = "(?<Final>" + F + ")(?<T>" + T + ")?";
            string loop2 = "(?<V>" + V + ")(" + loop1 + "|(?<T>" + T + "))?";

            string syllablepattern = "(?<AL>" + awl + ")|(?<AE>" + aone + ")|(?<U>" + au + ")|(?<ID>\u104C|\u104D|\u104E\u1004\u103A\u1038|\u104F)|(?<IV>[\u1023-\u102A])((?<T>" + T + ")|" + loop1 + ")?|(?<C>[\u1000-\u1021])((?<M>" + M + ")(\u103A|" + loop2 + "|" + loop1 + ")?|" + loop2 + "|" + loop1 + "|(?<K>\u103A)|\u1039)?";
            return syllablepattern;

        }

        private string preprocess_phono(string input)
        {
            input = Regex.Replace(input, "\u101A\u1031\u102C\u1000\u103A\u103B\u102C\u1038", "\u101A\u1031\u102C\u1000\u103A\u1000\u103B\u102C\u1038");
            input = Regex.Replace(input, "\u1000\u103B\u103D\u1014\u103A\u102F\u1015\u103A", "\u1000\u103B\u103D\u1014\u103A\u1014\u102F\u1015\u103A");
            input = Regex.Replace(input, "\u103F", "\u101E\u103A\u101E");
            input = Regex.Replace(input, "\u103A\u1039", "\u103A");
            return input;
        }

        private string insertbreak4phono(Match m)
        {
            if (breaker == ' ') return m.Value;
            else return m.Value + breaker;
        }

        public int GetPhonoCount(string input)
        {
            input = preprocess_phono(input);

            Regex re = new Regex(phonopattern());
            Match m = re.Match(input);
            int i = 0;
            while (m.Success)
            {
                i++;
                m = m.NextMatch();
            }
            return i;
        }

        public string PhonologicalBreaker(string input)
        {
            breaker = ' ';
            return PhonologicalBreaker(input, breaker);
        }

        public string PhonologicalBreaker(string input, char bsign)
        {
            breaker = bsign;
            string output;

            input = preprocess_phono(input);

            Regex re = new Regex(phonopattern());

            output = re.Replace(input, new MatchEvaluator(insertbreak4phono));

            return output;
        }

        public string[] GetPhonoArray(string input)
        {

            int size = GetPhonoCount(input);

            input = preprocess_phono(input);

            Regex re = new Regex(phonopattern());
            Match m = re.Match(input);

            string[] pc = new string[size];
            int i = 0;
            while (m.Success)
            {
                pc[i] = m.Value.ToString();
                i++;
                m = m.NextMatch();
            }

            return pc;

        }         
    }
}
