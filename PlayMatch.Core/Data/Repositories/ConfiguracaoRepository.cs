using PlayMatch.Core.Data.Interfaces;
using PlayMatch.Core.Models;
using SQLite;
using System.Threading.Tasks;

namespace PlayMatch.Core.Data.Repositories
{
    public class ConfiguracaoRepository : SQLiteRepository<Configuracao>, IConfiguracaoRepository
    {
        private readonly SQLiteAsyncConnection _database;

        public ConfiguracaoRepository(PlayMatchDbContext dbContext) : base(dbContext)
        {
            _database = dbContext.Database;
        }

        public async Task<T> GetConfiguracao<T>(string chave)
        {
            var config = await _database.Table<Configuracao>().FirstOrDefaultAsync(c => c.Chave == chave);
            if (config == null) throw new Exception($"Configuração '{chave}' não encontrada.");

            return config.Tipo switch
            {
                "int" => (T)Convert.ChangeType(int.Parse(config.Valor), typeof(T)),
                "bool" => (T)Convert.ChangeType(bool.Parse(config.Valor), typeof(T)),
                "datetime" => (T)Convert.ChangeType(DateTime.Parse(config.Valor), typeof(T)),
                _ => (T)Convert.ChangeType(config.Valor, typeof(T))
            };
        }

        public async Task<Dictionary<string, object>> GetTodasConfiguracoesAsync()
        {
            var listaConfiguracoes = await _database.Table<Configuracao>().ToListAsync();

            var configuracoes = new Dictionary<string, object>();

            foreach (var config in listaConfiguracoes)
            {
                object valorConvertido = config.Tipo switch
                {
                    "int" => int.Parse(config.Valor),
                    "bool" => bool.Parse(config.Valor),
                    "datetime" => DateTime.Parse(config.Valor),
                    _ => config.Valor // String padrão
                };

                configuracoes[config.Chave] = valorConvertido;
            }

            return configuracoes;
        }
    }
}

