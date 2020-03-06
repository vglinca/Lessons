using System;
using System.Diagnostics;

namespace Lesson8
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkWithExceptions();

            //WorkWithMultipleExceptions();
        }

        private static void WorkWithExceptions()
        {
            Console.Write("i = ");

            int i = Convert.ToInt32(Console.ReadLine());

            Console.Write("j = ");
            int j = Convert.ToInt32(Console.ReadLine());

            try
            {
                Check(i, j);
                Console.WriteLine($"i / j = {i / j}");
            } 
            catch (WrongNumberException e) when (j % 2 != 0)
            {
                Console.WriteLine($"{e.Message}\n{e.StackTrace}");
#if DEBUG
                throw;
#endif
            }
            catch (WrongNumberException e) when (i < 0)
            {
                Console.WriteLine($"{e.Message}\n");
#if DEBUG
                throw;
#endif
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Check(int i, int j)
        {
            if(i <= 0)
            {
                throw new WrongNumberException("First number must greater than zero.");
            }
            else if (j % 2 != 0)
            {
                throw new WrongNumberException("Second number must be even.");
            }
        }

        private static void WorkWithMultipleExceptions()
        {
            string conn = "DbConnectionString";
            string sta = "SELECT * FROM A";
            var f = true; 
            var s = false;

            try
            {
                Console.WriteLine("Connecting to database...");
                ConnectToDb(conn, f);
                Console.WriteLine($"Connection with connection string \"{conn}\" has successfully been opened.");
                ExecuteStatement(sta, s);
            } 
            catch (FailedConnectionException e)
            {
                Console.WriteLine($"Failed to connect to database.\n{e.StackTrace}");
                //throw;
            }
            catch (SqlStatementException e)
            {
                Console.WriteLine($"Failed to execute sql statement \"{sta}\".\n{e.StackTrace}");
                //throw;
            } 
            finally
            {
                CloseConnection(conn);
            }
        }

        private static void ConnectToDb(string conn, bool f)
        {
            if(!f)
            {
                throw new FailedConnectionException($"Could not connect to database with connection \"{conn}\"");
            }
            Console.WriteLine("connection succeed.");
        }
        private static void ExecuteStatement(string sta, bool s)
        {
            if(!s)
            {
                throw new SqlStatementException($"Something went wrong while executing statement \"{sta}\"");
            }
            Console.WriteLine("Statement succeed.");
        }
        private static void CloseConnection(string conn)
        {
            Console.WriteLine($"Connection \"{conn}\" has been closed.");
        }
    }

    public class WrongNumberException : Exception
    {
        public WrongNumberException(string msg) : base(msg)
        {
        }
    }

    public class FailedConnectionException : Exception
    {
        public FailedConnectionException(string msg) : base(msg)
        {
        }
    }

    public class SqlStatementException : Exception
    {
        public SqlStatementException(string msg) : base(msg)
        {
        }
    }
}
