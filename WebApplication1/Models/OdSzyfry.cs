using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class OdSzyfry: Szyfry
    {

        public static string odszyfrowanie_cezara(string tekst, int przesuniecie)
        {
            string tab = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż";
            string pom = "";
            for (int k = 0; k < tekst.Length; k++)
            {
                for (int y = 0; y < tab.Length; y++)
                {

                    if (tekst[k] == tab[y])
                    {
                        if ((y - przesuniecie) % 35 < 0)
                            pom += tab[35 + ((y - przesuniecie) % 35)];
                        else
                            pom += tab[(y - przesuniecie) % 35];
                    }
                }
            }
            return pom;
        }

        public static string odszyfrowanie_polibiusza(string tekst, bool taknie)
        {
            string tab = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż";
            string znak = "";
            string text = "";
            long pom = 0;
            if (taknie == true)
            {
                pom = Convert.ToInt64(tekst, 16);
                znak = pom.ToString();
            }
            else
                znak = tekst;
            int znak2 = 0;
            int znak3 = 0;
            int liczba;

            for (int i = 0; i < znak.Length; i = i + 2)
            {
                for (int j = 0; j < 2; j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        znak2 = int.Parse((znak[(i + j)]).ToString());
                        znak2 = (znak2 - 1) * 7;

                    }
                    else
                    {
                        znak3 = int.Parse(znak[(i + j)].ToString());
                        znak3 = (znak3 - 1);
                    }


                }
                liczba = znak2 + znak3;
                text += tab[liczba];
                liczba = 0;

            }
            return text;

        }
    }
}
