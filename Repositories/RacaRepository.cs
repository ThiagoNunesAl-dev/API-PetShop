using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using API_PetShop.Context;
using API_PetShop.Domains;
using API_PetShop.Interfaces;

namespace API_PetShop.Repositories
{
    public class RacaRepository : IRaca
    {
        PetShopContext conexao = new PetShopContext();

        SqlCommand cmd = new SqlCommand();

        public Raca Alterar(int id, Raca r)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "UPDATE Raca SET " +
                "Descricao = @descricao, " +
                "IdTipoDePet = @tipo WHERE IdRaca = @id ";

            cmd.Parameters.AddWithValue("@descricao", r.Descricao);
            cmd.Parameters.AddWithValue("@tipo", r.IdTipoDePet);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();

            return r;
        }

        public Raca BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM Raca WHERE IdRaca = @id";

            //Estabelece que o @id da linha acima é o mesmo id dado como argumento
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            Raca r = new Raca();

            while (dados.Read())
            {
                r.IdRaca = Convert.ToInt32(dados.GetValue(0));
                r.Descricao = dados.GetValue(1).ToString();
                r.IdTipoDePet = Convert.ToInt32(dados.GetValue(2));
            }

            conexao.Desconectar();

            return r;
        }

        public Raca Cadastrar(Raca r)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "INSERT INTO Raca (Descricao, IdTipoDePet) " +
                "VALUES " +
                "(@descricao, @idtipo)";
            cmd.Parameters.AddWithValue("@descricao", r.Descricao);
            cmd.Parameters.AddWithValue("@idtipo", r.IdTipoDePet);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();

            return r;
        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE FROM Raca WHERE IdRaca = @id";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
        }

        public List<Raca> LerTodos()
        {
            //Abrir a conexão
            cmd.Connection = conexao.Conectar();

            //Preparar a consulta
            cmd.CommandText = "SELECT * FROM Raca";

            //Executar a consulta
            SqlDataReader dados = cmd.ExecuteReader();

            //Criar a lista para guardar os tipos de pet
            List<Raca> racas = new List<Raca>();

            while (dados.Read())
            {
                racas.Add(
                    new Raca()
                    {
                        IdRaca = Convert.ToInt32(dados.GetValue(0)),
                        Descricao = dados.GetValue(1).ToString(),
                        IdTipoDePet = Convert.ToInt32(dados.GetValue(2)),
                    }
                );
            }

            //Fechar a Conexão
            conexao.Desconectar();

            return racas;
        }
    }
}
