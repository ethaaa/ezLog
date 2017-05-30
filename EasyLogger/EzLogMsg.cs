using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EasyLogger {
    public class EzLogMsg {
        private const char _defaultHorizontalFiller = '*';
        private const char _defaultVerticalFiller = '|';

        private string Message { get; set; }
        private Exception Exception { get; set; }
        public string Header { get; set; }
        public string Footer { get; set; }
        private char FillerHorizontal { get; set; }
        private char FillerVertical { get; set; }


        public EzLogMsg() { }
        public EzLogMsg(string msg) {
            Message = msg;
        }
        public EzLogMsg(Exception e) {
            Exception = e;
        }
        public EzLogMsg(string msg, Exception e) {
            Message = msg;
            Exception = e;
        }

        public List<string> GetFormattedMessage(int charsInTextLine) {
            List<string> msg = new List<string>();
            //Build message heading
            char fillerHorizontal = SetHorizontalFiller();
            char fillerVertical = SetVerticalFiller();

            List<string> header = BuildHeader(fillerHorizontal, charsInTextLine);
            List<string> linedMsg = BuildLinedMessage(Message, fillerVertical, charsInTextLine);
            List<string> footer = BuildFooter(fillerHorizontal, charsInTextLine);


            foreach (string line in header) {
                msg.Add(line);
            }
            foreach (string line in linedMsg) {
                msg.Add(line);
            }
            foreach (string line in footer) {
                msg.Add(line);
            }
            return msg;
        }

        private List<string> BuildLinedMessage(string message, char fillerVertical, int charsInTextLine) {
            List<string> linedMsg = new List<string>();
            //if message is shorter then the line, else split it over a few lines
            if((charsInTextLine - 2) >= message.Length) {
                linedMsg.Add(fillerVertical + message + fillerVertical);
            }
            else {
                //split on whitespace
                Regex regex = new Regex(@"\s");
                string[] bits = regex.Split(message);
                //current length starts with 2 because of the 2 side chars
                int currentLength = 2;
                int i = 0;

                StringBuilder stringBuilder = new StringBuilder();
                //Loop all words
                while (bits.Length > i) {
                    //if length of current line exedes max characters in a line
                    //and if there are words in the current line
                    //append the line and create a new one
                    if ((currentLength + bits[i].Length > charsInTextLine - 2) && (stringBuilder.Length > 0 && bits[i].Length < (charsInTextLine -2))) {
                        linedMsg.Add(fillerVertical + stringBuilder.ToString().PadRight(charsInTextLine - 2, ' ') + fillerVertical);
                        stringBuilder = new StringBuilder();
                        stringBuilder.Append(bits[i] + " ");
                        currentLength = 2 + bits[i].Length;
                    }
                    //if word is bigger then the character line devide it over a few lines
                    else if(bits[i].Length > (charsInTextLine - 2)) {
                        int startPos = 0;
                        while(bits[i].Length - startPos > 0) {
                            if((startPos + (charsInTextLine - 2)) > bits[i].Length) {
                                linedMsg.Add(fillerVertical + bits[i].Substring(startPos, bits[i].Length - startPos).PadRight(charsInTextLine - 2, ' ')  + fillerVertical);
                            }
                            else {
                                linedMsg.Add(fillerVertical + bits[i].Substring(startPos, charsInTextLine - 2) + fillerVertical);
                            }                            
                            startPos += (charsInTextLine - 2);
                        }
                        currentLength = 2;
                        stringBuilder = new StringBuilder();
                    }
                    //the words fits on the current line
                    else {
                        //enters get into the array too but have no length
                        if(bits[i].Length > 0) {
                            stringBuilder.Append(bits[i] + " ");
                            currentLength += (bits[i].Length + 1);
                        }
                        else {
                            linedMsg.Add(buildEmptyLine(fillerVertical, charsInTextLine));
                            currentLength = 2;
                            Console.WriteLine("EnterDetected");
                        }
                    }                    
                    i++;
                }
            }
            return linedMsg;
        }

        private List<string> BuildHeader(char fillerHorizontal, int charsInTextLine) {
            List<string> header = new List<string>();
            if (String.IsNullOrEmpty(Header)) {
                header.Add(new String(fillerHorizontal, charsInTextLine));
            }
            else {
                int headerLength = Header.Length;
                int headerHalfLength = headerLength / 2;
                string titel = Header;
                //center the header
                titel = titel.PadLeft(charsInTextLine / 2 + headerHalfLength, fillerHorizontal);
                titel = titel.PadRight(charsInTextLine, fillerHorizontal);

                header.Add(new String(fillerHorizontal, charsInTextLine));
                header.Add(titel);
                header.Add(new String(fillerHorizontal, charsInTextLine));
            }
            return header;
        }

        private List<string> BuildFooter(char fillerHorizontal, int charsInTextLine) {
            List<string> footer = new List<string>();
            if (String.IsNullOrEmpty(Footer)) {
                footer.Add(new String(fillerHorizontal, charsInTextLine));
            }
            else {
                int footerLength = Footer.Length;
                int footerHalfLength = footerLength / 2;
                string titel = Footer;
                //center the footer
                titel = titel.PadLeft(charsInTextLine / 2 + footerHalfLength, fillerHorizontal);
                titel = titel.PadRight(charsInTextLine, fillerHorizontal);

                footer.Add(new String(fillerHorizontal, charsInTextLine));
                footer.Add(titel);
                footer.Add(new String(fillerHorizontal, charsInTextLine));
            }
            return footer;
        }

        private string buildEmptyLine(char fillerHorizontal, int charsInTextLine) {
            return fillerHorizontal + "".PadRight(charsInTextLine - 2, ' ') + fillerHorizontal;
        }

        private char SetHorizontalFiller() {
            if (FillerHorizontal == '\0') {
                return _defaultHorizontalFiller;
            }
            else {
                return FillerHorizontal;
            }
        }

        private char SetVerticalFiller() {
            if (FillerVertical == '\0') {
                return _defaultVerticalFiller;
            }
            else {
                return FillerVertical;
            }
        }
    }
}
