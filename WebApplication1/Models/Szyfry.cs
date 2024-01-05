using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Szyfry
    {
        [Required]
        public string tekst { get; set; }
        [Required]
        public int przesuniecie { get; set; }
        public bool taknie { get; set; }
        public static string szyfr_cezara(string tekst, int przesuniecie)
        {
            string tab = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż";
            string tab2 = "AĄBCĆDEĘFGHIJKLŁMNŃOÓPQRSŚTUVWXYZŹŻ";
            string pom = "";
            string pom2 = "";

            for (int i = 0; i < tekst.Length; i++)
            {
                if (tekst[i] != ' ')
                {
                    pom += tekst[i];
                }

            }
            for (int l = 0; l < pom.Length; l++)
            {
                for (int j = 0; j < tab2.Length; j++)
                {
                    if (pom[l] == tab2[j])
                    {
                        pom2 += tab[j];
                    }
                    else if (pom[l] == tab[j])
                    {
                        pom2 += tab[j];
                    }

                }

            }
            pom = "";
            for (int k = 0; k < pom2.Length; k++)
            {
                for (int y = 0; y < tab.Length; y++)
                {

                    if (pom2[k] == tab[y])
                        pom += tab[(y + przesuniecie) % 35];
                }
            }
            return pom;
        }
        public static string szyfr_polibiusza(string tekst, bool taknie)
        {
            string tab = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż";
            string tab2 = "AĄBCĆDEĘFGHIJKLŁMNŃOÓPQRSŚTUVWXYZŹŻ";
            string pom = "";
            long a = 0;

            for (int k = 0; k < tekst.Length; k++)
            {
                for (int j = 0; j < 5; j++)
                {

                    for (int i = 0; i < 7; i++)
                    {
                        int liczba = (j * 7) + i;

                        if (tekst[k] == tab[liczba] || tekst[k] == tab2[liczba])
                        {
                            pom += ((j + 1) * 10) + (i + 1);
                        }
                    }
                }

            }
            a = long.Parse(pom);
            if (taknie == true)
            {
                return string.Format("{0:x}", a);
            }
            else
                return pom;

        }
    }
}

            
        

