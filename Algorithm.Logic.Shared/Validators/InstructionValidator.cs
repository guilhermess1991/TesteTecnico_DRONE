using System.Text.RegularExpressions;

namespace Algorithm.Logic.Shared.Validators
{
    public class InstructionValidator
    {
        public InstructionValidator(string instruction)
        {
            Instruction = instruction;        

            if(IsValid())
            {
                //Remove instruction followed by X
                while (Regex.IsMatch(Instruction, @"[Xx]"))
                {
                    var regex = new Regex(@"[SsNnLlOo]\d*?[Xx]");
                    Instruction = regex.Replace(Instruction, string.Empty);
                }                
            }            
        }
       
        public string Instruction { get; private set; }     

        public bool IsValid()
        {

            // Step 1. Verify if coordinate is valid
            // - Test 1. Is null or empty
            // - Test 2. Contains character X sequenced of digit.
            // - Test 3. Is obligatory that Coordinate contains always one character S,N,L or O.
            if (string.IsNullOrEmpty(Instruction)
                || Regex.IsMatch(Instruction, @"[X-x]\d")
                || Regex.IsMatch(Instruction, @"[^SsNnLlOoXx0-9]")
                || Regex.IsMatch(Instruction, @"^\d")
                || !Regex.IsMatch(Instruction, @"[A-Z]([1-9]|1\d{1,9}|20\d{8}|213\d{7}|2146\d{6}|21473\d{5}|214747\d{4}|2147482\d{3}|21474835\d{2}|214748364[0-6])?[A-Z]")
            )
            {
                Instruction = null;
                return false;
            }
            else
                return true;
        }
    }

}
    

