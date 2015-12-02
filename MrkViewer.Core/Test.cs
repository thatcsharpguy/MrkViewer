using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrkViewer.Core
{
    public class Test
    {
        public string TestMethod()
        {
            var txt =  @"# Ideone  
Ideone es un compilador en línea, es decir, tu puedes entrar a esta página web, escribir o copiar tu código ... dar click acá y nuestro código se compila y ejecuta.  

Existe una gran variedad de lenguajes que soporta el compilador, desde luego, al ser un sitio *gratuito* es muy probable que las implementaciones de los compiladores no sean las oficiales y en lugar de eso sean versiones soportadas por la comunidad, es decir. Open source.  

## ¿Es un IDE?  
A pesar del nombre, la parte de IDE, no lo podemos comparar con otras herramientas como Visual Studio o Eclipse puesto que como se ve, únicamente tenemos acceso a un editor de código y un botón de `Ejecutar`.  

## Entradas y salidas  
Para simular la entrada y salida estandar, digamos, el teclado y la pantalla, tenemos estos dos cajas de texto. La gran diferencia es que no es interactivo, tenemos que preeestablecer la entrada desde un inicio. No puedes venir acá y tratar de teclear algo, porque en definitiva no va a funcionar.

## ¿Qué se puede hacer con él?
Básicamente todo lo que se puede hacer con una aplicación de consola recién creada, salidas, entradas de texto. Tampoco esperes tener mucho soporte para librerías que no proporciona el framework.  
";
            return CommonMark.CommonMarkConverter.Convert(txt);

        }
    }
}
