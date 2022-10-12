using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// <summary>
// Interface Segregation Principle
// “Clients should not be forced to implement any methods they don't use. Rather than one fat interface,
// numerous little interfaces are preferred based on groups of methods with each interface serving one submodule“.
// </summary>
namespace DesignPatterns.SOLID
{
    public class Document
    {
    }

    public interface IMachine
    {
        void Print(Document d);
        void Scan(Document d);
        void Fax(Document d);
    }

    public class MultiFunctionPrinter : IMachine
    {
        public void Print(Document d)
        {
            //
        }

        public void Scan(Document d)
        {
            //
        }

        public void Fax(Document d)
        {
            //
        }
    }

    public class OldFashionedPrinter : IMachine
    {
        public void Print(Document d)
        {
            //
        }

        //what do we do in the situation where this type of equipment does not have the scan and fax function
        //we will implement more little interfaces
        public void Scan(Document d)
        {
            throw new NotImplementedException();
        }

        //what do we do in the situation where this type of equipment does not have the scan and fax function
        //we will implement more little interfaces
        public void Fax(Document d)
        {
            throw new NotImplementedException();
        }
    }

    public interface IPrinter
    {
        void Print(Document d);
    }

    public interface IScanner
    {
        void Scan(Document d);
    }

    public class Photocopier : IPrinter, IScanner
    {
        public void Print(Document d)
        {
            throw new NotImplementedException();
        }

        public void Scan(Document d)
        {
            throw new NotImplementedException();
        }
    }

    public interface IMultiFunctionDevice:IScanner,IPrinter //....
    {}

    public class MultiFunctionMachine : IMultiFunctionDevice
    {
        private readonly IPrinter printer;
        private readonly IScanner scanner;

        public MultiFunctionMachine(IPrinter printer, IScanner scanner)
        {
            this.printer = printer;
            this.scanner = scanner;
        }

        //delegate
        public void Print(Document d)
        {
            printer.Print(d);
        }

        //delegate
        public void Scan(Document d)
        {
            scanner.Scan(d);
            //decorator
        }
    }
}
