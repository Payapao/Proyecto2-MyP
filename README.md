# Base de datos musical (Proyecto2 de Modelado y Programación)

Sistema de gestión de canciones con Interfaz gráfica implementado mediante el Patrón de diseño Modelo Vista Controlador.

## Requisitos del Sistema

Para compilar y ejecutar el proyecto se requiere contar con las siguientes herramientas intaladas:

* SDK de .NET (C# 10+) y el sistema de construcción **Meson** (junto con **Ninja**).

## Instrucciones de Compilación y Ejecución

Navega a la carpeta correspondiente e utiliza Meson para compilar el proyecto:

     meson setup build	
     meson compile -C build
    ./build/proyecto2.exe -r ruta/del/directorio -a archivo.db (La bandera -a es opcional)