using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_PetShop.Domains;
namespace API_PetShop.Interfaces
{
    interface ITipoDePet
    {
        TipoDePet Cadastrar(TipoDePet t);
        List<TipoDePet> LerTodos();
        TipoDePet BuscarPorId(int id);
        TipoDePet Alterar(int id, TipoDePet t);
        void Excluir(int id);
    }
}
