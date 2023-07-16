using NLog;
using NLog.Web;

namespace PokeDex
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
            logger.Debug("開始初始化主程式。");
            try
            {
                var builder = WebApplication.CreateBuilder(args);

                // 重設原始 Log 記錄方式
                builder.Logging.ClearProviders();
                // 設定 Log 紀錄的最小等級
                builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Information);
                //將 NLog 註冊到此專案內
                builder.Host.UseNLog();

                builder.Services.AddControllers();
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();

                var app = builder.Build();

                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseHttpsRedirection();
                app.UseAuthorization();
                app.MapControllers();
                app.Run();
            }
            catch (Exception exception)
            {
                logger.Error(exception, "發生異常狀況，程式停止。");
            }
            finally
            {
                // 確保在應用程式退出之前刷新並停止內部計時器/執行續（避免 Linux 上的分段錯誤）
                LogManager.Shutdown();
            }
        }
    }
}