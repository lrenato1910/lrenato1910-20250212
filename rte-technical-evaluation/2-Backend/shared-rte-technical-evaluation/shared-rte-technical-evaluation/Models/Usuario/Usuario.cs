﻿namespace shared_rte_technical_evaluation.Models.Usuario;

public class Usuario
{
    public int id { get; set; }
    public string Login { get; set; }
    public string Senha { get; set; }
    public bool Ativo { get; set; }
}