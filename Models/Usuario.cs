using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySqlConnector;

namespace destinocerto.Models
{
    public class Usuario
    {
        private const string dados = "DataBase=destinocerto; Data Source=localhost; User Id=root;";


        public void conectar(){
            MySqlConnection conexao = new MySqlConnection(dados);
            MySqlCommand cmd = new MySqlCommand();
            conexao.Open();
            Console.WriteLine("Conectado");
            conexao.Close();
        }
        public void cadastrar(Usuariodatabase usuario){
            MySqlConnection con = new MySqlConnection(dados);
            con.Open();
            string query = "INSERT INTO usuarios(Nome, Senha) VALUES (@nome, @senha)";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@nome",usuario.Nome);
            cmd.Parameters.AddWithValue("@senha", usuario.senha);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void Editar(Usuariodatabase usuario){
             MySqlConnection con = new MySqlConnection(dados);
            con.Open();
            string query = "UPDATE usuarios SET Nome = @nome, Senha = @senha WHERE Id = @altname";
            MySqlCommand cmd = new MySqlCommand(query, con);
             cmd.Parameters.AddWithValue("@altname", usuario.Id);
            cmd.Parameters.AddWithValue("@nome", usuario.Nome);
            cmd.Parameters.AddWithValue("@senha", usuario.senha);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void Deletar(Usuariodatabase usuario){
           MySqlConnection con = new MySqlConnection(dados);
            con.Open();
            string query = "DELETE FROM usuarios WHERE Nome = @nome";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@nome", usuario.Nome);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public Usuariodatabase Validar(Usuariodatabase usuario){
            MySqlConnection con = new MySqlConnection(dados);
            con.Open();
            
            string query = "SELECT Nome, Senha FROM usuarios WHERE Nome=@nome AND Senha=@senha";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@nome", usuario.Nome);
            cmd.Parameters.AddWithValue("@senha", usuario.senha);
            MySqlDataReader reader = cmd.ExecuteReader();
             Usuariodatabase usercon = new Usuariodatabase();
           while(reader.Read()){
                 usercon.Nome = reader.GetString(0);
                 usercon.senha = reader.GetString(1); 
                 
           }
           
            con.Close();
            return usercon;
        }
       
        public List<Usuariodatabase> Listar(){
            MySqlConnection con = new MySqlConnection(dados);
            con.Open();
            string query = "SELECT * FROM usuarios ";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader reader = cmd.ExecuteReader();
              List<Usuariodatabase> lista = new List<Usuariodatabase>();
            
            while(reader.Read()){
                Usuariodatabase Usuariosco = new Usuariodatabase();
                Usuariosco.Id = reader.GetInt32("Id");
                if(reader.IsDBNull(reader.GetOrdinal("Nome")));
                Usuariosco.Nome = reader.GetString("Nome");
                if(reader.IsDBNull(reader.GetOrdinal("Senha")));
                Usuariosco.senha = reader.GetString("Senha");
                lista.Add(Usuariosco);    
            
            }
           
            con.Close();
            return lista;
        }
    }
}