namespace CORFileFormat
{
    class Program
    {
        static void Main(string[] args) 
        {
            FormatBase pdf1 = new PDF();
            FormatBase Word = new DOC();
            FormatBase PowerPoint = new PPTX();
            FormatBase Excel = new XLSX();

            pdf1.SetSuccessor(Word);
            Word.SetSuccessor(PowerPoint);
            PowerPoint.SetSuccessor(Excel);

            string? Result=null;

            pdf1.FormatChecker("XLSX", Result);
            Console.WriteLine( Result);
        }

        public abstract class FormatBase 
        {
            protected FormatBase _Successor;

            public abstract void FormatChecker(string Format, string? Result);

            public void SetSuccessor(FormatBase Successor)
            {
                _Successor= Successor;
            }
        }

        private class PDF : FormatBase
        {
            public override void FormatChecker(string Format, string? Result)
            {
                if (Format == "PDF")
                {
                    Console.WriteLine("PDF Reader opened document");
                }
                else
                {
                    Console.WriteLine("PDF Reader passes document to a different format opener");
                    _Successor.FormatChecker(Format, Result);
                }
            }
        }
        public class DOC : FormatBase
        {
            public override void FormatChecker(string Format, string? Result)
            {
                if (Format == "DOC")
                {
                    Console.WriteLine("DOC Reader opened document");
                }
                else
                {
                    Console.WriteLine("DOC Reader passes document to a different format opener");
                    _Successor.FormatChecker(Format, Result);
                }
            }
        }
        public class PPTX : FormatBase
        {
            public override void FormatChecker(string Format, string? Result)
            {
                if (Format == "PPTX")
                {
                    Console.WriteLine("PPTX Reader opened document");
                }
                else
                {
                    Console.WriteLine("PPTX Reader passes document to a different format opener");
                    _Successor.FormatChecker(Format, Result);
                }
            }
        }
        public class XLSX : FormatBase
        {
            public override void FormatChecker(string Format, string? Result)
            {
                if (Format == "XLSX")
                {
                    Console.WriteLine("XLSX Reader opened document");
                }
                else
                {
                    Console.WriteLine("XLSX Reader passes document to a different format opener");
                    _Successor.FormatChecker(Format, Result);
                }
            }
        }
    }

}
