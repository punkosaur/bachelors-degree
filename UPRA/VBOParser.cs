using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UPRA
{
    internal class VBOParser
    {
        private string filePath {  get; set; }

        private List<string> inputs { get; set; }
        private List<string> combouts { get; set; }
        private List<string> interimAutomatStates { get; set; }
        private List<string> comboutStateChunks { get; set; }
        private List<string> comboutOutputChunks { get; set; }
        private List<string> interimOutputs { get; set; }
        private List<string> outputs { get; set; }

        public VBOParser(string filePath) {
            this.filePath = filePath;

            this.inputs = getInputs();
            this.combouts = getCombouts();
            this.interimAutomatStates = getInterimStates();
            this.comboutStateChunks = getStateChunks();
            this.comboutOutputChunks = getOutputChunks();
            this.interimOutputs = getInterimOutputs();
            this.outputs = getOutputs();
        }

        public string toLangC(string line)
        {
            line = line.Replace('~', '_');
            line = line.Replace('#', '|');
            line = line.Replace('!', '~');
            line = line.Replace('$', '^');
            return line;
        }
        private string cleanLine(string line)
        {
            line = line.Replace("~input_o", "");
            line = line.Replace("-- \\", "");
            line = line.Replace("-- pragma translate_off", "");
            line = line.Replace("-- ", "");
            line = line.Replace("\\", "");
            line = line.Replace("/", "");
            line = line.Replace("fstate.", "");
            line = line.Replace("_combout", "");
            line = line.Replace("\t", "");

            ////////////////////
            line = line.Replace("~", "_");
            line = line.Replace("#", "||");
            //line = line.Replace("!", "~");
            line = line.Replace("$", "^");
            line = line.Replace("&", "&&");
            ////////////////////

            return line;
        }

        public List<string> getStateChunks()
        {
            List<string> chunks = new List<string>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                string chunk = "";
                bool insideChunk = false;
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Trim().StartsWith("-- \\fstate.") && !insideChunk)
                    {
                        chunk = cleanLine(line);
                        insideChunk = true;
                    }
                    else if (insideChunk)
                    {
                        if (!string.IsNullOrWhiteSpace(cleanLine(line)))
                        {
                            chunk += cleanLine(line);
                        }
                        if (line.Trim().StartsWith("-- pragma translate_off"))
                        {
                            chunks.Add(chunk);
                            insideChunk = false;
                            chunk = "";
                        }
                    }
                }
                sr.Close();
            }

            return chunks;
        }

        public List<string> getOutputChunks()
        {
            List<string> chunks = new List<string>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                string chunk = "";
                bool insideChunk = false;
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Trim().StartsWith("-- \\") && !insideChunk && !line.Contains("-- \\fstate."))
                    {
                        chunk = cleanLine(line);
                        insideChunk = true;
                    }
                    else if (insideChunk)
                    {
                        if (!string.IsNullOrWhiteSpace(cleanLine(line)))
                        {
                            chunk += cleanLine(line);
                        }
                        if (line.Trim().StartsWith("-- pragma translate_off"))
                        {
                            chunks.Add(chunk);
                            insideChunk = false;
                            chunk = "";
                        }
                    }
                }
                sr.Close();
            }

            return chunks;
        }

        public List<string> getInputs()
        {
            List<string> inputs = new List<string>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    //if (line.StartsWith("SIGNAL \\\\") && line.EndsWith("~input_o : std_logic;"))
                    
                    if (line.StartsWith("SIGNAL \\") && line.Trim().EndsWith("input_o\\ : std_logic;"))
                    {
                        line = line.Replace("~input_o\\ : std_logic;", "");
                        line = line.Replace("SIGNAL \\", "");
                        line = toLangC(line);
                        inputs.Add(line.Trim());
                    }
                }
                sr.Close();
            }

            //inputs.Remove("reset");
            //inputs.Remove("clock");

            return inputs;
        }

        public List<string> getOutputs(){

            List<string> outputs = new List<string>();

            using (StreamReader sr = new StreamReader(filePath)){
                string line;
                while ((line = sr.ReadLine()) != null){

                    if (line.StartsWith("SIGNAL \\") && line.Trim().EndsWith("~output_o\\ : std_logic;")){
                        line = line.Replace("~output_o\\ : std_logic;", "");
                        line = line.Replace("SIGNAL \\", "");
                        line = toLangC(line);
                        outputs.Add(line.Trim());
                    }
                }
                sr.Close();
            }
            return outputs;
        }

        public List<string> getInterimOutputs()
        {

            List<string> outputs = new List<string>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {

                    if (line.StartsWith("SIGNAL \\") && line.Trim().EndsWith("_combout\\ : std_logic;") && !line.Contains("fstate."))
                    {
                        line = line.Replace("_combout\\ : std_logic;", "");
                        line = line.Replace("SIGNAL \\", "");
                        line = toLangC(line);
                        outputs.Add(line.Trim());
                    }
                }
                sr.Close();
            }
            return outputs;
        }

        public List<string> getCombouts()
        {

            List<string> states = new List<string>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {

                    if (line.StartsWith("SIGNAL \\") && line.Trim().EndsWith("_combout\\ : std_logic;") && line.Contains("fstate."))
                    {
                        line = line.Replace("_combout\\ : std_logic;", "");
                        line = line.Replace("fstate.", "");
                        line = line.Replace("SIGNAL \\", "");
                        line = toLangC(line);
                        states.Add(line.Trim());
                    }
                }
                sr.Close();
            }
            return states;
        }

        public List<string> getInterimStates()
        {

            List<string> states = new List<string>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {

                    if (line.StartsWith("SIGNAL \\") && line.Trim().EndsWith("~q\\ : std_logic;") && line.Contains("fstate."))
                    {
                        line = line.Replace("\\ : std_logic;", "");
                        line = line.Replace("fstate.", "");
                        line = line.Replace("SIGNAL \\", "");
                        line = toLangC(line);
                        states.Add(line.Trim());
                    }
                }
                sr.Close();
            }
            return states;
        }

        public string inputCheckString()
        { 
            List<string> inputs = getInputs();

            string txt = "Inputs: ";
            for(int i=0;i<inputs.Count;i++)
            {
                txt += inputs[i] + " ";
            }
            return  txt;
        }

        public string outputCheckString()
        {
            List<string> outputs = getOutputs();

            string txt = "Outputs: ";
            for (int i = 0; i < outputs.Count; i++)
            {
                txt += outputs[i] + " ";
            }
            return txt;
        }

        public string interimOutputCheckString()
        {
            List<string> outputs = getInterimOutputs();

            string txt = "Interim outputs: ";
            for (int i = 0; i < outputs.Count; i++)
            {
                txt += outputs[i] + " ";
            }
            return txt;
        }

        public string comboutsCheckString()
        {
            List<string> states = getCombouts();

            string txt = "Combouts: ";
            for (int i = 0; i < states.Count; i++)
            {
                txt += states[i] + " ";
            }
            return txt;
        }

        public string interimStatesCheckString()
        {
            List<string> states = getInterimStates();

            string txt = "Interim automat states: ";
            for (int i = 0; i < states.Count; i++)
            {
                txt += states[i] + " ";
            }
            return txt;
        }

        public string statesChunksCheckString()
        {
            List<string> chunks = getStateChunks();

            string txt = "Combouts: ";
            for (int i = 0; i < chunks.Count; i++)
            {
                txt += chunks[i] + Environment.NewLine;
            }
            return txt;
        }

        public string outputChunksCheckString()
        {
            List<string> chunks = getOutputChunks();

            string txt = "OutputCombouts: ";
            for (int i = 0; i < chunks.Count; i++)
            {
                txt += chunks[i] + Environment.NewLine;
            }
            return txt;
        }

        public string initList(List<string> list)
        {
            string init = "";

            switch (list.Count)
            {
                case 0:
                    break;

                case 1:
                    init += "_Bool ";
                    init += list[0];
                    init += ";";
                    break;

                default:
                    init += "_Bool ";
                    init += list[0];
                    for (int i = 1; i < list.Count; i++)
                    {
                        init += ", ";
                        init += list[i];
                    }
                    init += ";";
                    break;
            }
            return init;

        }

        public string assignNull(List<string> list)
        {
            string assings = "";
            for (int i = 0; i < list.Count; i++) assings += list[i] + " = 0;" + Environment.NewLine;
            //assings += Environment.NewLine;
            return assings;
        }

        public string assignAutmateStatesInterim()
        {
            string assings = "";
            for (int i = 0; i < interimAutomatStates.Count; i++)
            {
                string cutstate = interimAutomatStates[i].Replace("_q", "");

                List<string> lst = new List<string>();

                foreach (string c in combouts)
                {
                    if (c.StartsWith(cutstate)) lst.Add(c.Trim());
                }

                if (lst.Count > 0) assings += "\t" + cutstate + "_q = " + lst[lst.Count - 1] + ";" + Environment.NewLine;
            }
            return assings;
        }
        public string assignOutputsFromInterim()
        {
            string assings = "";
            for (int i = 0; i < outputs.Count; i++)
            {
                string output = outputs[i];

                List<string> lst = new List<string>();

                foreach (string c in interimOutputs)
                {
                    if (c.StartsWith(output)) lst.Add(c.Trim());
                }

                if (lst.Count > 0) assings += "\t" + output +" = "+ lst[lst.Count - 1] + ";" + Environment.NewLine;
            }
            return assings;
        }

        public string getFuncsFromChunks(List<string> list)
        {
            string assings = "";
            for (int i = 0; i < list.Count; i++) assings += "\t" + list[i] + ";" + Environment.NewLine;
            return assings;
        }

        public string fullCheck()
        {
            string txt = "";
            txt += inputCheckString() + Environment.NewLine;
            txt += outputCheckString() + Environment.NewLine;
            txt += interimOutputCheckString() + Environment.NewLine;
            txt += comboutsCheckString() + Environment.NewLine;
            txt += interimStatesCheckString() + Environment.NewLine;
            txt += statesChunksCheckString() + Environment.NewLine;
            txt += outputChunksCheckString() + Environment.NewLine;
            return txt;
        }

        public string genCode()
        {
            string txt = "";
            txt += initList(inputs) + Environment.NewLine;
            txt += initList(combouts) + Environment.NewLine;
            txt += initList(interimAutomatStates) + Environment.NewLine;
            txt += initList(interimOutputs) + Environment.NewLine;
            txt += initList(outputs) + Environment.NewLine;
            txt += Environment.NewLine;
            txt += assignNull(inputs) + Environment.NewLine;
            txt += assignNull(interimAutomatStates) + Environment.NewLine;
            txt += assignNull(interimOutputs) + Environment.NewLine;

            txt += "while(1){" + Environment.NewLine;

            //txt += Environment.NewLine;
            //txt += "\ta = (HAL_GPIO_ReadPin(MY_IN0_GPIO_Port, MY_IN0_Pin) == GPIO_PIN_SET) ? 1 : 0;" + Environment.NewLine +
            //    "\tb = (HAL_GPIO_ReadPin(MY_IN1_GPIO_Port, MY_IN1_Pin) == GPIO_PIN_SET) ? 1 : 0;" + Environment.NewLine;
            //txt += Environment.NewLine;

            txt += getFuncsFromChunks(comboutStateChunks);
            txt += Environment.NewLine;
            txt += assignAutmateStatesInterim();
            txt += Environment.NewLine;
            txt += getFuncsFromChunks(comboutOutputChunks);
            txt += Environment.NewLine;
            txt += assignOutputsFromInterim();
            txt += Environment.NewLine;


            //txt += "\tHAL_GPIO_WritePin(MY_OUT0_GPIO_Port, MY_OUT0_Pin, Z1);" + Environment.NewLine +
            //    "\tHAL_GPIO_WritePin(MY_OUT1_GPIO_Port, MY_OUT1_Pin, Z2);" + Environment.NewLine;
            //txt += Environment.NewLine;
            txt += "\tHAL_Delay(25);";
            txt += Environment.NewLine;


            txt += "}" + Environment.NewLine;

            return txt;
        }


        public string rebuildWithInOutputs(List<(string,string)> inputsList, List<(string, string)> outputsList)
        {
            string txt = "";
            txt += initList(inputs) + Environment.NewLine;
            txt += initList(combouts) + Environment.NewLine;
            txt += initList(interimAutomatStates) + Environment.NewLine;
            txt += initList(interimOutputs) + Environment.NewLine;
            txt += initList(outputs) + Environment.NewLine;
            txt += Environment.NewLine;
            txt += assignNull(inputs) + Environment.NewLine;
            txt += assignNull(interimAutomatStates) + Environment.NewLine;
            txt += assignNull(interimOutputs) + Environment.NewLine;

            txt += "while(1){" + Environment.NewLine;

            txt += Environment.NewLine;
            for (int i = 0; i < inputsList.Count; i++)
            {
                if (inputsList[i].Item2 != "")
                {
                    txt += "\t" + inputsList[i].Item1 +
                           " = (HAL_GPIO_ReadPin(" + inputsList[i].Item2 + "_GPIO_Port, " + inputsList[i].Item2 + "_Pin) == GPIO_PIN_SET) ? 1 : 0;" +
                           Environment.NewLine;
                }
            }
            txt += Environment.NewLine;

            txt += getFuncsFromChunks(comboutStateChunks);
            txt += Environment.NewLine;
            txt += assignAutmateStatesInterim();
            txt += Environment.NewLine;
            txt += getFuncsFromChunks(comboutOutputChunks);
            txt += Environment.NewLine;
            txt += assignOutputsFromInterim();
            txt += Environment.NewLine;


            for (int i = 0; i < outputsList.Count; i++)
            {
                if (outputsList[i].Item2 != "")
                {
                    txt += "\tHAL_GPIO_WritePin(" + outputsList[i].Item2 + "_GPIO_Port, " + outputsList[i].Item2 + "_Pin, "+ outputsList[i].Item1 +");" +Environment.NewLine;
                }
            }


            txt += Environment.NewLine;
            txt += "\tHAL_Delay(25);";
            txt += Environment.NewLine;


            txt += "}" + Environment.NewLine;

            return txt;
        }
    }
}
