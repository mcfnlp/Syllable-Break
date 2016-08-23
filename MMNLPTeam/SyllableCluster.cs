using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

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
            string VA2 = "\u1031(\u102B|\u102C)\u1037\u103A";
            string V = "\u1031(\u102B|\u102C)?|\u102D(\u102F|\u1036)?|\u102B|\u102C|\u102E|\u102F(\u1036)?|\u1030|\u1032|\u1036";
            string F = "[\u1000-\u1021](\u1037)?(\u103A(\u1039)?|\u1039)";
            string FF = "[\u1000-\u1021](" + M + ")?(\u1037)?(\u103A)";
            // string FF2 = "[\u1000-\u1021](" + M + ")?(" + V+ ")?[\u1000-\u1021](\u1037)?(\u103A)";

            string T = "\u1037|\u1038";
            string D = "([\u1040-\u1049](\\.([\u1040-\u1049])+)*)+";
            //string Seng = "([\u0061-\u007A]*)+";
            //string Ceng = "([\u0041-\u005A]*)+";

            //string Eng = "((?<Seng>"+Seng+")?|(?<Ceng>"+Ceng+")?)*";
            string loop1 = "(?<Final>" + F + ")(?<T>" + T + ")?(" + FF + ")*";
            string loop2 = "((?<VA>" + VA + ")(?<T>" + T + ")?|(?<VA2>" + VA2 + ")(?<T>" + T + ")?|(?<V>" + V + ")(" + loop1 + "|(?<T>" + T + "))?)(" + FF + ")*";

            string loopsa = "(?<Gsa>" + GSa + ")((?<M>" + M + ")(" + loop2 + "|" + loop1 + ")?|" + loop2 + "|" + loop1 + "|\u1039)?";
            string floop = "((?<Final>" + F + ")(?<T>" + T + ")?(" + FF + ")*|" + loopsa + ")";
            string vloop = "((?<VA>" + VA + ")(?<T>" + T + ")?|(?<VA2>" + VA2 + ")(?<T>" + T + ")?|(?<V>" + V + ")(" + floop + "|(?<T>" + T + "))?)(" + FF + ")*";

            //string syllablepattern = "(?<ID>\u104C|\u104D|\u104E\u1004\u103A\u1038|\u104F)|(?<IV>[\u1023-\u102A])((?<T>" + T + ")|" + floop + ")?|" + D + "|" + Man + "|" + Me + "|(?<C>[\u1000-\u1021])((?<M>" + M + ")(" + vloop + "|" + floop + ")?|" + vloop + "|" + floop + "|\u1039)?";
            //return syllablepattern;
            string mypattern = "(?<ID>\u104C|\u104D|\u104E\u1004\u103A\u1038|\u104F)|(?<IV>[\u1023-\u102A])((?<T>" + T + ")|" + floop + ")?|" + D + "|" + Man + "|" + Me + "|(?<C>[\u1000-\u1021])((?<M>" + M + ")(" + vloop + "|" + floop + ")?|" + vloop + "|" + floop + "|\u1039)?";
            return mypattern;

        }
        private string insertbreak4ortho(Match m)
        {
            string temp = m.Value.ToString();
            if (temp[temp.Length - 1].Equals('\u1039') | temp[temp.Length - 1].Equals('\u002d') | temp[temp.Length - 1].Equals('\u0067') | temp[temp.Length - 1].Equals('\u002e')) temp = temp;
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
            string result = SplitEng(output, breaker);  //edit
            return result;

        }
        public string SplitEng(string output, char breaker)
        {
            string[] C = new string[] { "\u1000", "\u1001", "\u1002", "\u1003", "\u1004", "\u1005", "\u1006", "\u1007", "\u1008", "\u1009", "\u100A", "\u100B", "\u100C", "\u100D", "\u100E", "\u100F", "\u1010", "\u1011", "\u1012", "\u1013", "\u1014", "\u1015", "\u1016", "\u1017", "\u1018", "\u1019", "\u101A", "\u101B", "\u101C", "\u101D", "\u101E", "\u101F", "\u1020", "\u1021" }; //myanmar consonants
            string[] Eng = new string[] { "\u0061", "\u0062", "\u0063", "\u0064", "\u0065", "\u0066", "\u0067", "\u0068", "\u0069", "\u006A", "\u006B", "\u006C", "\u006D", "\u006E", "\u006F", "\u0070", "\u0071", "\u0072", "\u0073", "\u0074", "\u0075", "\u0076", "\u0077", "\u0078", "\u0079", "\u0079", "\u007A", "\u0041", "\u0042", "\u0043", "\u0044", "\u0045", "\u0046", "\u0047", "\u0048", "\u0049", "\u004A", "\u004B", "\u004C", "\u004D", "\u004E", "\u004F", "\u0050", "\u0051", "\u0052", "\u0053", "\u0054", "\u0055", "\u0056", "\u0057", "\u0058", "\u0059", "\u005A", "\u0021", "\u0022", "\u0023", "\u0024", "\u0025", "\u0026", "\u0027", "\u0028", "\u0029", "\u002A", "\u002C", "\u002D", "\u002E", "\u002F", "\u003A", "\u003B", "\u003C", "\u003D", "\u003E", "\u003F", "\u0040", " ", "?", "။", "၊", "Á", "À" }; //English Consonants small & capital
            string result = "";
            char bsign = breaker;

            string[] strarr;
            strarr = output.Split(bsign);
            int k = 0;
            for (int i = 0; i < strarr.Length; i++)
            {
                char[] input = strarr[i].ToCharArray();
                if (strarr[i] != "")
                {
                    if (!Eng.Contains(input[k].ToString()))
                    {
                        result += strarr[i] + bsign.ToString();
                    }
                    else
                    {
                        for (int j = 0; j < input.Length; j++)
                        {
                            if (Eng.Contains(input[j].ToString()))
                            {
                                if (j + 1 != input.Length)
                                {
                                    if (C.Contains(input[j + 1].ToString()))
                                    {
                                        result += input[j].ToString() + bsign.ToString();
                                    }
                                    else
                                        result += input[j].ToString();
                                }
                                else
                                    result += input[j].ToString();
                            }
                            else
                                result += input[j].ToString();
                        }
                        result += bsign.ToString();
                    }

                }
            }
            //result = Regex.Replace(result, "", "");
            return result;
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
            string V = "\u1031(\u102B(\u1037)?(\u103A)?|\u102C(\u1037)?(\u103A)?)?|\u102D(\u102F|\u1036)?|\u102B|\u102C|\u102E|\u102F(\u1036)?|\u1030|\u1032|\u1036";
            string F = "[\u1000-\u1021](\u1037)?(\u103A|\u1039)";
            string FF = "[\u1000-\u1021](" + M + ")?(\u1037)?(\u103A)";//Editing (03-05-2011)
            string T = "\u1037|\u1038";

            string loop1 = "(?<Final>" + F + ")(?<T>" + T + ")?(" + FF + ")*";
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
            string result = SplitEng(output, breaker);  //edit
            return result;
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
