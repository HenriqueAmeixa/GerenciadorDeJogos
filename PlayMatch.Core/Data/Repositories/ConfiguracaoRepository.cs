using PlayMatch.Core.Data;
using PlayMatch.Core.Models;
using SQLite;

public class ConfiguracaoRepository : SQLiteRepository<Configuracao>, IConfiguracaoRepository
{
    private readonly SQLiteAsyncConnection _database;

    public ConfiguracaoRepository(PlayMatchDbContext dbContext) : base(dbContext)
    {
        _database = dbContext.Database;
    }

    public async Task<List<Configuracao>> GetTodasConfiguracoesAsync()
    {
        return await _database.Table<Configuracao>().ToListAsync();
    }
    public async Task<Configuracao> GetConfiguracaoAsync(string chave)
    {
        return await _database.Table<Configuracao>()
            .FirstOrDefaultAsync(c => c.Chave == chave);
    }
    public async Task AtualizarConfiguracaoAsync(Configuracao configuracao)
    {
        var configExistente = await GetConfiguracaoAsync(configuracao.Chave);

        if (configExistente != null)
        {
            configExistente.Valor = configuracao.Valor; // Apenas o valor é atualizado
            await _database.UpdateAsync(configExistente);
        }
        else
        {
            throw new KeyNotFoundException($"Configuração '{configuracao.Chave}' não encontrada.");
        }
    }
}
