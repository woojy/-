using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace _3111_우재윤
{
    public partial class Form1 : Form
    {
        List<char> alpha = new List<char>(); //알파벳 a~z 까지 저장될 변수
        List<char> amhokey = new List<char>(); //암호키가 저장될 변수
        List<char> result = new List<char>(); //중복제거된 암호키가 저장될 리스트
        List<char> ch = new List<char>();//평문이 하나 하나 저장될 char 리스트
        List<char> sub = new List<char>(); //치환된 암호문이 저장될 리스트
        List<char> bok = new List<char>(); //복호화된 암호문이 저장될 리스트 
        List<char> plain; //복호화된 암호문이 저장될 리스트  s

        string amho="";
        string plainText = ""; //평문
        string cryptogram = ""; //암호문이 찍힐 textbox

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            amho = textBox1.Text;
            plainText = textBox2.Text; //평문
            cryptogram = textBox3.Text; //암호문이 찍힐 textbox

            for (char i = 'a'; i <= 'z'; i++)
            {
                //알파벳을 순서대로 List에 넣어줌
                alpha.Add(i);
            }
            amho = amho.ToLower(); //암호키 모두 소문자
            plainText = plainText.ToLower(); //얘도
            plainText = plainText.Trim();//얘는 평문 공백지우기

            for (int i = 0; i < amho.Length; i++)
            {
                //암호키를 result 리스트에 넣어주기
                result.Add(amho[i]);
                result = result.Distinct().ToList();//암호키 중복제거
            }
            for (char c = result.LastOrDefault(); c <= 'z'; c++) //마지막 알파벳부터 'z'까지 넣기
            {
                result.Add(c);
                result = result.Distinct().ToList();//암호문 중복제거
            }

            if (result.Count < 26) //만약 암호문이 꽉차지 않았으면
            {
                for (char c = 'a'; c <= 'z'; c++) //다시 a부터 넣어라
                {
                    result = result.Distinct().ToList();//암호문 중복제거
                    result.Add(c); //나머지 뒤에 쫘르륵 넣기
                }
            }

            for (int i = 0; i < plainText.Length; i++)
            {
                //평문의 알파벳 하나 하나 list에 저장
                ch.Add(plainText[i]);
            }

            for (int i = 0; i < ch.Count; i++) //평문에 맞는 index가져오기
            {
                for (int j = 0; j < 26; j++)
                {
                    if (ch[i] == alpha[j]) //평문 [i] 랑 alpha[i] 비교해서 찾으면
                    {
                        sub.Add(result[j]); //sub 배열에 암호판 [i]넣기
                    }
                }
            }
            foreach (char i in sub) //암호문 텍스트박스에 암호화된 문자찍기
            {
                textBox3.Text += i;
            }

            for (int i = 0; i < sub.Count; i++) //암호화문에 맞는 alpha가져오기
            {
                for (int j = 0; j < 26; j++)
                {
                    if (sub[i] == result[j])
                    {
                        bok.Add(alpha[j]);
                    }
                }
            }
            foreach (char i in bok) //암호문 텍스트박스에 복호화된 문자찍기
            {
                textBox4.Text += i;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            alpha.Clear();
            amhokey.Clear(); //암호키가 저장될 변수
            result.Clear(); //중복제거된 암호키가 저장될 리스트
            ch.Clear();//평문이 하나 하나 저장될 char 리스트
            sub.Clear(); //치환된 암호문이 저장될 리스트
        }
    }
}
