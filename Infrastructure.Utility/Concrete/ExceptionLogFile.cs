using NLog;

namespace Infrastructure.Utility.Concrete
{
    public class ExceptionLogFile
    {
        static void Exception(string[] args)
        {
            Commander commander = new Commander();
            commander.StartTransaction();
            commander.DoSomething();
            commander.StopTransaction();
        }
    }
        public class Commander
        {
            Logger logger = LogManager.GetCurrentClassLogger();

            public void StartTransaction()
            {
                logger.Info("Gonderim baslatildi");
            }
            public void DoSomething()
            {
                logger.Fatal("Servis calismiyor");
                logger.Error("Servis DB ye kayıt yapmıyor");
            }
            public void StopTransaction()
            {
                logger.Warn("Transaction sonlandı ama işlem tamamlanmadı");
            }
        }
    }