using System;
using Android.Content;
using Android.Util;
using AndroidX.Work;
using Xamarin.Essentials;

namespace ExemploWorkerAndroidForms.Droid
{
    public class MeuWorker : Worker
    {
        public MeuWorker(Context context, WorkerParameters workerParams)
          : base(context, workerParams)
        {
        }

        public override Result DoWork()
        {
            try
            {
                Log.Info("Teste", $"{DateTime.Now} Iniciando Serviço de BackGround ");

                Log.Info("Local", $"{DateTime.Now} Acessando para Testar");

                return new Result.Retry();
            }
            catch(Exception ex)
            {
                return new Result.Failure();
            }
        }
    }
}
