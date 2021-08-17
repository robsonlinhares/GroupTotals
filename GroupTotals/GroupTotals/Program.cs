using System;
using System.Collections.Generic;
using System.Linq;

namespace GroupTotals
{
    public class Program
    {
        public static string GroupTotals(string[] strArr)
        {       
            var groupTotals = new List<GroupTotalsDto>();

            foreach (var str in strArr)
            {
                var grupoTotal = str.Split(":");               
                groupTotals.Add(CriarGroupTotals(grupoTotal[0], Convert.ToInt32(grupoTotal[1])));
            }    

            return FormatarGroupTotals(groupTotals);
        }

        static void Main(string[] args)
        {
            Console.WriteLine(GroupTotals(new string[] { "X:-1", "Y:1", "X:-4", "B:3", "X:5" }));
        }

        private static string FormatarGroupTotals(List<GroupTotalsDto> groupTotals)
        {
            var groupTotalsFormatado = groupTotals
                      .GroupBy(g => g.Chave)
                      .ToDictionary(d => d.Key, s => s.Sum(v => v.Valor))
                      .Where(g => g.Value != 0).OrderBy(g => g.Key).ToList();

            return string.Join(", ", groupTotalsFormatado.Select(g => $"{g.Key}:{g.Value}"));
        }

        private static GroupTotalsDto CriarGroupTotals(string chave, int valor)
        {
            return new GroupTotalsDto
            {
                Chave = chave,
                Valor = valor
            };
        }

        private class GroupTotalsDto
        {
            public string Chave { get; set; }
            public int Valor { get; set; }
        }
    }
}
