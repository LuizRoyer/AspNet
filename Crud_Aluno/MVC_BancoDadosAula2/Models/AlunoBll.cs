using Microsoft.Extensions.Configuration;
using Crud_Aluno.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace Crud_Aluno.Models
{
    public class AlunoBll : IAlunoBll
    {      
    public List<Aluno> GetAlunos()
    {
        var configuration = ConfigurationHelper.GetConfiguration(Directory.GetCurrentDirectory());
        var conexaoString = configuration.GetConnectionString("DefaultConnection");
        List<Aluno> listaAlunos = new List<Aluno>();
        try
        {
            using (SqlConnection con = new SqlConnection(conexaoString))
            {
                StringBuilder sqlSelect = new StringBuilder();
                sqlSelect.Append("Select * From [Escola].[dbo].[Aluno]");

                SqlCommand cmd = new SqlCommand(sqlSelect.ToString(), con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    listaAlunos.Add(new Aluno
                    {
                        Id = Convert.ToInt16(rdr["ID"].ToString()),
                        Nome = rdr["NOME"].ToString(),
                        Sexo = rdr["SEXO"].ToString(),
                        DataNascimento = Convert.ToDateTime(rdr["DATANASCIMENTO"].ToString()),
                        Email = rdr["EMAIL"].ToString(),
                        Foto = rdr["FOTO"].ToString(),
                        Texto = rdr["TEXTO"].ToString()
                    });
                }
                return listaAlunos;
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public void IncluirAluno(Aluno aluno)
    {
        var configuration = ConfigurationHelper.GetConfiguration(Directory.GetCurrentDirectory());
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                StringBuilder sqlInsert = new StringBuilder();
                sqlInsert.Append(@"INSERT INTO [Escola].[dbo].[Aluno]
                                   (NOME,SEXO,DATANASCIMENTO,EMAIL,FOTO,TEXTO) 
                                      VALUES
                                    (@Nome ,@Sexo ,@DataNascimento,@Email,@Foto,@Texto)");

                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlInsert.ToString(), conn);

                cmd.Parameters.Add(new SqlParameter { ParameterName = "@Nome", Value = aluno.Nome });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@Sexo", Value = aluno.Sexo });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@DataNascimento", Value = aluno.DataNascimento });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@Email", Value = aluno.Email });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@Foto", Value = aluno.Foto });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@Texto", Value = aluno.Texto });

                cmd.ExecuteNonQuery();
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
    public void AtualizarAluno(Aluno aluno)
    {
        var configuration = ConfigurationHelper.GetConfiguration(Directory.GetCurrentDirectory());
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                StringBuilder sqlUpdate = new StringBuilder();
                sqlUpdate.Append(@"Update [Escola].[dbo].[Aluno]
                                      set NOME =@Nome
                                          ,SEXO=@Sexo
                                          ,DATANASCIMENTO=@DataNascimento
                                          ,EMAIL=@Email
                                          ,FOTO=@Foto
                                          ,TEXTO=@Texto
                                      where Id= @Id ");

                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlUpdate.ToString(), conn);
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@Id", Value = aluno.Id });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@Nome", Value = aluno.Nome });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@Sexo", Value = aluno.Sexo });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@DataNascimento", Value = aluno.DataNascimento });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@Email", Value = aluno.Email });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@Foto", Value = aluno.Foto });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@Texto", Value = aluno.Texto });

                cmd.ExecuteNonQuery();
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public void DeletarAluno(int id)
    {
        var configuration = ConfigurationHelper.GetConfiguration(Directory.GetCurrentDirectory());
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                StringBuilder sqlDelete = new StringBuilder();
                sqlDelete.Append(@"Delete from [Escola].[dbo].[Aluno]
                                        where Id = @id");
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlDelete.ToString(), conn);
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@id", Value = id });

                cmd.ExecuteNonQuery();
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}
}
