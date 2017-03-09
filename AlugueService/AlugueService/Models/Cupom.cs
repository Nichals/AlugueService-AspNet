using System;

namespace AlugueService.Models
    {
    public class Cupom
        {
        public Cupom()
            {


            }
        public int idCupom { get; set; }
        public Cliente cliente { get; set; }
        public Operador operador { get; set; }
        public float valor { get; set; }
        public int status { get; set; }
        public DateTime dataInclusao { get; set; }
                
        }
    }