using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaCenaMultyPlayer : ControlaCena
{
    private ControlaJogo[] jogos;
    private bool alguemMorto;
    private int pontosDesdeAMorte;

    protected override void Start()
    {
        base.Start();
        jogos = FindObjectsOfType<ControlaJogo>();
    }
    
    public void AlguemMorreu()
    {
        alguemMorto = true;
        pontosDesdeAMorte = 0;
    }
    
    public void ContabilizarPontosPosMorte()
    {
        if (alguemMorto)
        {
            pontosDesdeAMorte++;
        }

        if (pontosDesdeAMorte > 2)
        {
            Reviver();
        }
    }
    
    private void Reviver()
    {
        foreach (var jogo in jogos)
        {
            jogo.Ativar();
        }

        alguemMorto = false;
    }
}
