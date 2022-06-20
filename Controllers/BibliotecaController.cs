using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiBiblioteca.Models;
using ApiBiblioteca.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiBiblioteca.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BibliotecaController : ControllerBase
    {
        RepositoryBibliotecas repo;

        public BibliotecaController(RepositoryBibliotecas repo)
        {
            this.repo = repo;
        }

        // https://apibiblioteca.azurewebsites.net/biblioteca
        [HttpGet]
        public ActionResult<List<Biblioteca>> Get()
        {
            return this.repo.GetLibros();
        }

        // https://apibiblioteca.azurewebsites.net/Biblioteca/GetId/
        [HttpGet("[action]/{id}")]
        public ActionResult<Biblioteca> GetId(int idlibro)
        {
            return this.repo.BuscarLibros(idlibro);
        }

        // https://apibiblioteca.azurewebsites.net/Biblioteca/GetTitulo/
        [HttpGet("[action]/{titulo}")]
        public ActionResult<List<Biblioteca>> GetTitulo(String titulo)
        {
            return this.repo.BuscarLibrosTitulo(titulo);
        }

        // https://apibiblioteca.azurewebsites.net/Biblioteca/GetTitulos/
        [HttpGet("[action]/{titulo}")]
        public ActionResult<List<Biblioteca>> GetTitulos(String titulo)
        {
            return this.repo.BuscarLibrosTituloLike(titulo);
        }

        // https://apibiblioteca.azurewebsites.net/biblioteca/GetAutor/
        [HttpGet("[action]/{autor}")]
        public ActionResult<List<Biblioteca>> GetAutor(String autor)
        {
            return this.repo.BuscarLibrosAutor(autor);
        }

        // https://apibiblioteca.azurewebsites.net/biblioteca/GetAutores/
        [HttpGet("[action]/{autor}")]
        public ActionResult<List<Biblioteca>> GetAutores(String autor)
        {
            return this.repo.BuscarLibrosAutorLike(autor);
        }

        // https://apibiblioteca.azurewebsites.net/biblioteca/GetTematica/
        [HttpGet("[action]/{tematica}")]
        public ActionResult<List<Biblioteca>> GetTematica(String tematica)
        {
            return this.repo.BuscarLibrosTematica(tematica);
        }

        // Peticion POST para Insert en Base de Datos
        // https://apibiblioteca.azurewebsites.net/biblioteca/
        [HttpPost]
        public void InsertarLibro(Biblioteca biblioteca)
        {
            this.repo.InsertarLibro
                (biblioteca.IdLibro ,
                 biblioteca.Titulo, biblioteca.Autor, biblioteca.Tematica, biblioteca.UrlDescarga, biblioteca.ImagenPortada);
        }

        // Peticion PUT para Modificar en Base de Datos
        // https://apibiblioteca.azurewebsites.net/biblioteca/ModificarLibro/
        [HttpPut]
        public void ModificarDepartamento(Biblioteca biblioteca)
        {
            this.repo.ModificarLibro(biblioteca.IdLibro
                , biblioteca.Titulo, biblioteca.Autor, biblioteca.Tematica, biblioteca.UrlDescarga, biblioteca.ImagenPortada);
        }

        // Peticion DELETE para Borrar en Base de Datos
        // https://apibiblioteca.azurewebsites.net/biblioteca/
        [HttpDelete("{id}")]
        public void EliminarLibro(int id)
        {
            this.repo.EliminarLibro(id);
        }

    }
}