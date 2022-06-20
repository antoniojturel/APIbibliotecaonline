using ApiBiblioteca.Data;
using ApiBiblioteca.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBiblioteca.Repositories
{
    public class RepositoryBibliotecas
    {
        BibliotecaContext context;

        public RepositoryBibliotecas(BibliotecaContext context)
        {
            this.context = context;
        }

        public List<Biblioteca> GetLibros()
        {
            return this.context.Bibliotecas.ToList();
        }

        public Biblioteca BuscarLibros(int idlibro)
        {
            return this.context.Bibliotecas.SingleOrDefault(z => z.IdLibro == idlibro);
        }

        public List<Biblioteca> BuscarLibrosTitulo(String titulo)
        {
            return this.context.Bibliotecas.Where(x => x.Titulo == titulo).ToList();
        }

        public List<Biblioteca> BuscarLibrosTituloLike(String titulo)
        {
            return this.context.Bibliotecas.Where (x => x.Titulo.Contains(titulo)).ToList();
        }

        public List<Biblioteca> BuscarLibrosAutor(String autor)
        {
            return this.context.Bibliotecas.Where(x => x.Autor == autor).ToList();
        }

        public List<Biblioteca> BuscarLibrosAutorLike(String autor)
        {
            return this.context.Bibliotecas.Where(x => x.Autor.Contains(autor)).ToList();
        }

        public List<Biblioteca> BuscarLibrosTematica(String tematica)
        {
            return this.context.Bibliotecas.Where(x => x.Tematica == tematica).ToList();
        }

        public void InsertarLibro(int num, String titulo, String autor, String tematica, String url, String portada)
        {
            Biblioteca libro = new Biblioteca();
            libro.IdLibro = num;
            libro.Titulo = titulo;
            libro.Autor = autor;
            libro.Tematica = tematica;
            libro.UrlDescarga = url;
            libro.ImagenPortada = portada;
            this.context.Bibliotecas.Add(libro);
            this.context.SaveChanges();
        }

        public void ModificarLibro(int num, String titulo, String autor, String tematica, String url, String portada)
        {
            Biblioteca libro = this.BuscarLibros(num);
            libro.IdLibro = num;
            libro.Titulo = titulo;
            libro.Autor = autor;
            libro.Tematica = tematica;
            libro.UrlDescarga = url;
            libro.ImagenPortada = portada;
            this.context.SaveChanges();
        }

        public void EliminarLibro(int num)
        {
            Biblioteca libro = this.BuscarLibros(num);
            this.context.Bibliotecas.Remove(libro);
            this.context.SaveChanges();
        }

    }
}