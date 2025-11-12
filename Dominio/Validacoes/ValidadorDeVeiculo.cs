using MinimalApi.DTOs;
using MinimalApi.Dominio.ModelViews;

namespace MinimalApi.Dominio.Validacoes;

public class ValidadorDeVeiculo
{
    public ErrosDeValidacao Validar(VeiculoDTO dto)
    {
        var erros = new List<string>();

        if (string.IsNullOrWhiteSpace(dto.Nome))
            erros.Add("O campo Nome é obrigatório.");

        if (string.IsNullOrWhiteSpace(dto.Marca))
            erros.Add("O campo Marca é obrigatório.");

        if (dto.Ano <= 0)
            erros.Add("O campo Ano deve ser maior que zero.");

        return new ErrosDeValidacao { Mensagens = erros };
    }
}
