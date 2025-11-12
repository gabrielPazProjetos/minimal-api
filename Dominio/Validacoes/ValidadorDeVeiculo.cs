using MinimalApi.DTOs;
using MinimalApi.Dominio.ModelViews;

namespace MinimalApi.Dominio.Validacoes;

public class ValidadorDeAdministrador
{
    public ErrosDeValidacao Validar(AdministradorDTO dto)
    {
        var erros = new List<string>();

        if (string.IsNullOrWhiteSpace(dto.Email))
            erros.Add("O campo Email é obrigatório.");

        if (string.IsNullOrWhiteSpace(dto.Senha))
            erros.Add("O campo Senha é obrigatório.");

        if (dto.Perfil == null)
            erros.Add("O campo Perfil é obrigatório.");

        return new ErrosDeValidacao { Mensagens = erros };
    }
}
