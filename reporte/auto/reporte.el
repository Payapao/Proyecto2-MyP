;; -*- lexical-binding: t; -*-

(TeX-add-style-hook
 "reporte"
 (lambda ()
   (TeX-add-to-alist 'LaTeX-provided-class-options
                     '(("article" "12pt")))
   (TeX-add-to-alist 'LaTeX-provided-package-options
                     '(("geometry" "margin=1in") ("enumitem" "") ("dirtree" "") ("fontawesome5" "") ("inputenc" "utf8") ("multicol" "") ("fontenc" "T1") ("tabularx" "") ("fancyhdr" "") ("titlesec" "") ("lmodern" "") ("helvet" "") ("hyperref" "hidelinks" "breaklinks=true") ("mdframed" "framemethod=tikz") ("hf-tikz" "customcolors") ("tcolorbox" "most") ("tgheros" "") ("listings" "") ("babel" "spanish") ("xcolor" "svgnames" "table" "") ("graphicx" "") ("float" "") ("tikz" "")))
   (add-to-list 'LaTeX-verbatim-environments-local "lstlisting")
   (add-to-list 'LaTeX-verbatim-macros-with-braces-local "lstinline")
   (add-to-list 'LaTeX-verbatim-macros-with-braces-local "href")
   (add-to-list 'LaTeX-verbatim-macros-with-braces-local "hyperimage")
   (add-to-list 'LaTeX-verbatim-macros-with-braces-local "hyperbaseurl")
   (add-to-list 'LaTeX-verbatim-macros-with-braces-local "nolinkurl")
   (add-to-list 'LaTeX-verbatim-macros-with-braces-local "url")
   (add-to-list 'LaTeX-verbatim-macros-with-braces-local "path")
   (add-to-list 'LaTeX-verbatim-macros-with-delims-local "lstinline")
   (add-to-list 'LaTeX-verbatim-macros-with-delims-local "path")
   (TeX-run-style-hooks
    "latex2e"
    "article"
    "art12"
    "geometry"
    "enumitem"
    "dirtree"
    "fontawesome5"
    "inputenc"
    "multicol"
    "fontenc"
    "tabularx"
    "fancyhdr"
    "titlesec"
    "lmodern"
    "helvet"
    "hyperref"
    "xcolor"
    "mdframed"
    "hf-tikz"
    "tcolorbox"
    "tgheros"
    "listings"
    "babel"
    "graphicx"
    "float"
    "tikz")
   (TeX-add-symbols
    '("pb" 1)
    "recordatorio"
    "foldericon"
    "pdficon"
    "txticon"
    "zipicon"
    "digitwidth")
   (LaTeX-add-labels
    "fig:conexion"
    "fig:servidor"
    "fig:cliente")
   (LaTeX-add-counters
    "recordatorioCounter")
   (LaTeX-add-xcolor-definecolors
    "softpurple"
    "antiquefuchsia"
    "foldercolor"
    "pdfcolor"
    "readmecolor")
   (LaTeX-add-listings-lstdefinestyles
    "mystyle"))
 :latex)

