using System;

namespace Algorithm.Domain.Entities
{
    public class Drone
    {
        public Drone()
        {
            CoordenadaX = 0;
            CoordenadaY = 0;
        }

        public int CoordenadaX { get; set; }

        public int CoordenadaY { get; set; }

        public void Move(Tuple<string,int> instruction)
        {            
         
            switch (instruction.Item1)
            {
                case "N":                    
                    CoordenadaY = CoordenadaY + instruction.Item2;                   
                    break;

                case "S":                   
                    CoordenadaY = CoordenadaY - instruction.Item2;
                    break;

                case "L":              
                    CoordenadaX = CoordenadaX + instruction.Item2;                   
                    break;

                case "O":                  
                    CoordenadaX = CoordenadaX - instruction.Item2;                   
                    break;
            }
        }        

        public void InvalidMove()
        {
            CoordenadaX = 999;
            CoordenadaY = 999;
        }

        public override string ToString()
        {
            return $"({CoordenadaX}, {CoordenadaY})";
        }
    }
}
