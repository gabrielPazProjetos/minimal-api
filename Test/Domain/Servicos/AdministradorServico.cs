using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Interfaces;
using MinimalApi.DTOs;
using MinimalApi.Infraestrutura.Db;

namespace MinimalApi.Dominio.Servicos;

public class AdministradorServico : IAdministradorServico
{
    private readonly DbContexto _contexto;

    public AdministradorServico(DbContexto contexto)
    {
        _contexto = contexto;
    }

    public Administrador? Login(LoginDTO loginDTO)
    {
        return _contexto.Administradores
            .FirstOrDefault(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha);
    }

    public void Incluir(Administrador administrador)
    {
        _contexto.Administradores.Add(administrador);
        _contexto.SaveChanges();
    }

    public IEnumerable<Administrador> Todos(int? pagina)
    {
        int tamanhoPagina = 10;
        int numeroPagina = pagina ?? 1;

        return _contexto.Administradores
            .OrderBy(a => a.Id)
            .Skip((numeroPagina - 1) * tamanhoPagina)
            .Take(tamanhoPagina)
            .ToList();
    }

    public Administrador? BuscaPorId(int id)
    {
        return _contexto.Administradores.FirstOrDefault(a => a.Id == id);
    }
}
