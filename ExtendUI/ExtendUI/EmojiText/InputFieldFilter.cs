namespace ExtendUI.EmojiText
{
    using System.Text.RegularExpressions;
    using UnityEngine;
    using UnityEngine.UI;

    public class InputFieldFilter : MonoBehaviour
    {

        private InputField inputField;
        // Use this for initialization
        void Start()
        {

            if (inputField == null)
            {
                inputField = GetComponent<InputField>();
            }

            inputField.onValueChanged.AddListener(onValueChanged);
        }

        void onValueChanged(string str)
        {
            //string item = "";
            MatchCollection matches = Regex.Matches(str, @"\[([^\]]*)\]");
            for (int i = 0; i < matches.Count; i++)
            {
                //item = matches[i].Value;
                //str = str.Replace(item, NornalStr(item));
                //Debug.Log(string.Format("i:{0},  item:{1}",i, matches[i].Value));
                //NornalStr(matches[i].Value);
                //str = str.Replace(item, NornalStr(item));
                str = str.Replace(matches[i].Value, NornalStr(matches[i].Value));
            }
            inputField.text = str;
        }
        string NornalStr(string str)
        {
            string strs = Regex.Replace(str, @"[^a-z0-9A-Z]", "");
            if (strs.Length > 1)
            {
                strs = strs.Substring(0, 1);
            }
            //string strs = Regex.Replace(str,   @"\\^[a-z0-9A-Z]+\\]", "");
            //Debug.Log(string.Format("==========> 之前值：{0},之后值{1}", str, strs));
            //return strs;
            return string.Format("[{0}]", strs);
        }


    }
}
