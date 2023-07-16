using NLog;
using NLog.Web;

namespace PokeDex
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
            logger.Debug("�}�l��l�ƥD�{���C");
            try
            {
                var builder = WebApplication.CreateBuilder(args);

                // ���]��l Log �O���覡
                builder.Logging.ClearProviders();
                // �]�w Log �������̤p����
                builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Information);
                //�N NLog ���U�즹�M�פ�
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
                logger.Error(exception, "�o�Ͳ��`���p�A�{������C");
            }
            finally
            {
                // �T�O�b���ε{���h�X���e��s�ð�����p�ɾ�/������]�קK Linux �W�����q���~�^
                LogManager.Shutdown();
            }
        }
    }
}