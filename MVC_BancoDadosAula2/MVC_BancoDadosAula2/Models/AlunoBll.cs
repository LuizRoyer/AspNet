using Microsoft.Extensions.Configuration;
using MVC_BancoDadosAula2.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace MVC_BancoDadosAula2.Models
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
                using(SqlConnection con = new SqlConnection(conexaoString))
                {
                    StringBuilder sqlSelect = new StringBuilder();
                    sqlSelect.Append("Select * From [Escola].[dbo].[Aluno]");
                    
                    SqlCommand cmd = new SqlCommand(sqlSelect.ToString(), con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        listaAlunos.Add(new Aluno {
                            Id = Convert.ToInt16(rdr["ID"].ToString()),
                            Nome = rdr["NOME"].ToString(),
                            Sexo = rdr["SEXO"].ToString(),
                            DataNascimento = Convert.ToDateTime(rdr["DATANASCIMENTO"].ToString())
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
                                   (NOME,SEXO,DATANASCIMENTO) 
                                      VALUES
                                    (@Nome ,@Sexo ,@DataNascimento)");

                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlInsert.ToString(), conn);
                 
                    SqlParameter paramNome = new SqlParameter();
                    paramNome.ParameterName = "@Nome";
                    paramNome.Value = aluno.Nome;
                    cmd.Parameters.Add(paramNome);

                    SqlParameter paramSexo = new SqlParameter();
                    paramSexo.ParameterName = "@Sexo";
                    paramSexo.Value = aluno.Sexo;
                    cmd.Parameters.Add(paramSexo);

                    SqlParameter paramDataNascimento = new SqlParameter();
                    paramDataNascimento.ParameterName = "@DataNascimento";
                    paramDataNascimento.Value = aluno.DataNascimento;
                    cmd.Parameters.Add(paramDataNascimento);
                                     
                    cmd.ExecuteNonQuery();
                }
            }catch(Exception e)
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
                                      where Id= @Id ");

                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlUpdate.ToString(), conn);

                    SqlParameter paramId = new SqlParameter();
                    paramId.ParameterName = "@Id";
                    paramId.Value = aluno.Id;
                    cmd.Parameters.Add(paramId);

                    SqlParameter paramNome = new SqlParameter();
                    paramNome.ParameterName = "@Nome";
                    paramNome.Value = aluno.Nome;
                    cmd.Parameters.Add(paramNome);

                    SqlParameter paramSexo = new SqlParameter();
                    paramSexo.ParameterName = "@Sexo";
                    paramSexo.Value = aluno.Sexo;
                    cmd.Parameters.Add(paramSexo);

                    SqlParameter paramDataNascimento = new SqlParameter();
                    paramDataNascimento.ParameterName = "@DataNascimento";
                    paramDataNascimento.Value = aluno.DataNascimento;
                    cmd.Parameters.Add(paramDataNascimento);
                    
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
