using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace destinocerto.Models
{
    public class Pacote : Controller
    {
        private const string dados = "DataBase=destinocerto; Data Source=localhost; User Id=root;";
           public void cadastrar(decpacote pacote){
            MySqlConnection con = new MySqlConnection(dados);
            con.Open();
            string query = "INSERT INTO pacote(Nome, Valor, Descriçao) VALUES (@nome, @valor, @descriçao)";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@nome",pacote.Nome);
            cmd.Parameters.AddWithValue("@valor", pacote.Valor);
            cmd.Parameters.AddWithValue("@descriçao", pacote.Descriçao);
            cmd.ExecuteNonQuery();
            con.Close();
        }
          public List<decpacote> Ordenar(){
            MySqlConnection con = new MySqlConnection(dados);
            con.Open();
            string query = "SELECT * FROM pacote ";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader reader = cmd.ExecuteReader();
              List<decpacote> lista = new List<decpacote>();
            
            while(reader.Read()){
               decpacote pacote = new decpacote();
                pacote.Id = reader.GetInt32("Id");
                if(reader.IsDBNull(reader.GetOrdinal("Nome")));
                pacote.Nome = reader.GetString("Nome");
                if(reader.IsDBNull(reader.GetOrdinal("Valor")));
                pacote.Valor = reader.GetDouble("Valor");
                pacote.Descriçao = reader.GetString("Descriçao");
                lista.Add(pacote);    
            
            }
            con.Close();
            return lista;
    }
      public void Delete(decpacote pacote){
           MySqlConnection con = new MySqlConnection(dados);
            con.Open();
            string query = "DELETE FROM pacote WHERE Nome = @nome";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@nome", pacote.Nome);
            cmd.ExecuteNonQuery();
            con.Close();
        }
         public void Update(decpacote pacote){
             MySqlConnection con = new MySqlConnection(dados);
            con.Open();
            string query = "UPDATE pacote SET Nome = @nome, Valor = @valor, Descriçao = @descriçao WHERE id = @altname";
            MySqlCommand cmd = new MySqlCommand(query, con);
             cmd.Parameters.AddWithValue("@altname", pacote.Id);
            cmd.Parameters.AddWithValue("@nome", pacote.Nome);
            cmd.Parameters.AddWithValue("@valor", pacote.Valor);
            cmd.Parameters.AddWithValue("@descriçao", pacote.Descriçao);
            cmd.ExecuteNonQuery();
            con.Close();
        }
}
}