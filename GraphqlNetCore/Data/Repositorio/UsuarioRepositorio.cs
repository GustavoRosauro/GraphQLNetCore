using GraphqlNetCore.Data.Repositorio;
using GraphqlNetCore.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlNetCore.Data
{
    public class UsuarioRepositorio
    {
        private readonly ApexDBContext _context;
        public UsuarioRepositorio(ApexDBContext context)
        {
            _context = context;
        }
        public async Task<List<Usuario>> ObterUsuarios(UsuarioFiltro filtro)
        {
            var query = _context.Usuarios.AsTracking();
            if (filtro.Id.HasValue && filtro.Id > 0)
            {
                query = query.Where(w => w.Id == filtro.Id);
            }
            if (!string.IsNullOrEmpty(filtro.Nome))
            {
                query = query.Where(w => filtro.Nome.Contains(w.Nome));
            }
            return await query.ToListAsync();
        }
        public Usuario Alterar(Usuario usuario)
        {
            _context.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }
        public Usuario ObterUsuarioPorId(int id)
        {
            return _context.Usuarios.First(x => x.Id == id);
        }
        public void Remover(Usuario usuario)
        {
            _context.Remove(usuario);
            _context.SaveChanges();
        }
    }
}
