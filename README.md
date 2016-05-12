Índice
1.	Introducción	2
1.1.	TIPO CONECTOR	2
1.2.	APERTURA Y CIERRE DE CONEXIONES	2
1.3.	CAMPOS DE ORDENACIÓN Y FILTROS	3
1.4.	DIFERENTES SENTENCIAS SQL CON MISMOS RESULTADOS	3
2.	Objetivos	4
2.1.	OBJETIVOS	4
2.2.	PLANIFICACIÓN	4
3.	Diseño	5
3.1.	REQUERIMIENTOS	5
3.2.	CASOS DE USO	5
3.3.	DISEÑO	5
3.4.	MOCKUPS	5
4.	Tecnologías y Herramientas	6
4.1.	.NET FRAMEWORK	6
4.2.	C#	8
4.3.	WINFORMS	9
4.4.	VISUAL STUDIO 2010 - IDE	10
4.5.	GIT Y GITHUB	11
4.5.1.	Git	12
4.5.2.	GitHub	12
5.	Implementación	14
5.1.	METODOLOGÍA	14
5.1.1.	Metodología mixta	14
5.1.2.	TDD	14
5.2.	PROGRAMACIÓN ORIENTADA A OBJETOS	14
5.3.	PATRONES DE DISEÑO	14
5.4.	GUI	14
6.	Control de calidad y pruebas	15
7.	Resultados y conclusiones	16
8.	Vocabulario	17
9.	Anexos	18
A.	MANUAL DE USUARIO	18
10.	Referencias y bibliografía	19
 
1.	Introducción 
Este proyecto surge como una propuesta de la profesora Cristina Ausina, con un enfoque más genérico como una aplicación para poder probar distintos Sistemas Gestores de Bases de Datos (SGBD) centrándonos sobre todo en poder compararlos entre sí, SGBD SQL, NoSQL, y ORMs.
Viendo la dificultad en poder hacer comparaciones entre sistemas que no comparten nada y que sus finalidades son distintas, y que los ORMs no son más que capas sobre un SGBD para encapsular funcionalidad y acabar obteniendo el esquema en objetos dentro del lenguaje, no tenía mucho sentido estas comparaciones, ya que iban a ser siempre más lentas.
Lo que si tenía sentido era centrarnos en los SGBD de tipo SQL, y no solo para compararlos entre ellos, sino para poder comparar distintos conectores y distintas consultas de un mismo SGBD.
1.1.	Tipo conector 
En muchas ocasiones nos hemos encontrado con aplicaciones, tanto de escritorio como aplicaciones Web, en las que la conexión con la base de datos se realiza mediante conexión ODBC, siendo el SGBD MySQL, Oracle o incluso SQL Server, teniendo estos SGBD conectores nativos para casi todos los lenguajes, y siempre nos ha surgido la duda, realmente merecerá la pena el realizar los cambios necesarios para usar un conector nativo en vez de usarlo de tipo ODBC, en algunos lenguajes los cambios entre uno, u otro tipo, son menores y dependiendo de cómo este desarrollada la aplicación, podemos tener el cambio realizado con una mínima inversión. 
Pero siempre nos queda la duda de si este cambio habrá merecido realmente la pena, o simplemente es un cambio anecdótico.
1.2.	Apertura y cierre de conexiones  
En otro caso, nos encontramos ante una aplicación Web legada, nos ponen en antecedentes comentándonos que es una aplicación desarrollada en PHP, que en un principio usaba MySQL pero que con el tiempo tuvieron que migrarla a Oracle, ya que MySQL no era capaz de soportar el tráfico y que incluso determinadas partes más pesadas, tuvieron que migrarlas de PHP en Apache, a Java en Tomcat ya que continuaban teniendo problemas.
Revisando el código, se descubre que los desarrolladores anteriores en cada método que necesitaban lanzar una consulta a la base de datos, previamente abrían la conexión, y al acabar el método cerraban dicha conexión, si una página necesitaba obtener los datos de varias tablas, y los métodos iban llamando a otros métodos, se iban realizando aperturas de conexiones en cascada a la base de datos, llegando en algunos casos a que la misma petición de un cliente tuviera entre 20 y 30 conexiones abiertas.
1.3.	Campos de ordenación y filtros  
En otros casos, desarrollamos la aplicación en base a unas especificaciones, todo parece funcionar correctamente, la llevamos a producción, el cliente comienza a usarla, y ocurren estas dos situaciones:
1 – En cuanto la base de datos comienza a crecer, determinadas secciones se hacen cada vez más lentas.
2 – En un apartado en particular, los clientes quieren poder filtrar u ordenar por un campo que en principio no estaba previsto, y al permitir dicha acción, el rendimiento cae en picado.
En estos casos, puede ser algo muy sencillo de solucionar, generando los índices necesarios, para no perder rendimiento, o puede ser algo más difícil de encontrar, teniendo que cambiar el orden o la forma de unir determinadas consultas.
En cualquiera de los casos, poder contar con una aplicación que nos permita lanzan una batería de consultas sobre una base de datos, guardarnos los resultados y poder repetir el proceso conforme vayamos realizando cambios, para poder en base a estas medidas tomadas, saber si los cambios son beneficiosos.
1.4.	Diferentes sentencias SQL con mismos resultados 

 

 
2.	Objetivos
2.1.	Objetivos
El objetivo principal es la creación de una aplicación que nos permita configurar una serie de test, que permitan ejecutarse contra distintos conectores de Bases de Datos y recoja los resultados en ficheros XML, que nos permitan abrir estos en formato PDF con los resultados convertidos a gráficos que nos permitan procesar la información de una forma más visual.
Específicamente la aplicación deberá tener las siguientes secciones:
•	Configurar los conectores a Base de Datos que podremos usar.
•	Configurar los Test, con cada una de sus secciones.
•	Permitir ejecutar un Test sobre una lista de conectores
•	Guardar los resultados en XML
•	Permitir abrir estos resultados y convertirlos en PDF con un formato más visual con gráficas.
•	Permitir comparar varios resultados.
A nivel personal, con el proyecto se busca:
•	Obtener la titulación de Desarrollo de Aplicaciones Multiplataforma.
•	Utilizar patrones de diseño y respetar los principios de Clean Code en la medida de lo posible, para mejorar mi uso de ellos.
•	Aprender a usar los Test Unitarios dentro de un proyecto de .NET
•	Obtener una aplicación que nos permita mayor flexibilidad a la hora de tomar decisiones sobre el resultado de determinadas consultas.
2.2.	Planificación

 
3.	Diseño
3.1.	Requerimientos
Windows XP o superior, con .NET 4.0 instalado.
Un SGDB con conector ODBC, o MySQL con el conector nativo de .Net o el ODBC.
3.2.	Casos de uso

3.3.	Diseño

3.4.	Mockups

 
4.	Tecnologías y Herramientas
4.1.	.Net Framework
.Net Framework es un entorno de desarrollo y ejecución de aplicaciones de Microsoft, que aglutina una serie de tecnologías (ASP.NET, Web Services, WinForms, ADO.NET, Biblioteca de clases .NET, WCF, WPF) específicamente diseñadas para poder crear todo tipo de aplicaciones.

El corazón de .Net Framework es el CLR (Common Language Runtime), que es el encargado de gestionar la ejecución de código compilado para la plataforma .NET. Puede asimilarse a la máquina virtual de Java.
Las aplicaciones son compiladas y ejecutadas dentro del CLR, de forma similar a las aplicaciones Java que son ejecutadas dentro de su máquina virtual.
A estas aplicaciones les ofrece numerosos servicios para facilitar su desarrollo y mantenimiento y favorecen su fiabilidad y seguridad. 
Las dos principales características del CLR son:
•	Ejecución multiplataforma: El CLR actúa como una máquina virtual, encargándose de ejecutar las aplicaciones diseñadas para la plataforma .NET. Su especificación está abierta, por lo que cualquier plataforma para la que exista una versión del CLR podrá ejecutar cualquier aplicación .NET. En la actualidad Microsoft ha adquirido Xamarin que es una implementación libre de la plataforma de desarrollo .NET para dispositivos Android, iOS y GNU/Linux.
•	Integración de lenguajes: Desde cualquier lenguaje para el que exista un compilador que genere código para la plataforma .NET es posible utilizar código generado para la misma usando cualquier otro lenguaje tal y como si de código escrito usando el primero se tratase. Ejemplos C#, Visual Basic .Net, MC++, JScript.Net, F#, Cobol.Net.
Para que un lenguaje de programación sea soportado por la plataforma .NET, ha de existir un compilador que traduzca de este lenguaje a MSIL ("managed code"). A la hora de ejecutar el código intermedio, éste es siempre compilado a código nativo.

Otras características destacables son:
•	Modelo de programación consistente: A todos los servicios y facilidades ofrecidos por el CLR se accede de la misma forma: a través de un modelo de programación orientado a objetos.
•	Eliminación del "infierno de las DLLs": En la plataforma .NET desaparece el problema conocido como "infierno de las DLLs" que se da en los sistemas operativos actuales de la familia Windows ya que en la plataforma .NET las versiones nuevas de las DLLs pueden coexistir con las viejas.
•	Gestión de memoria: El CLR incluye un recolector de basura que evita que el programador tenga que tener en cuenta cuándo ha de destruir los objetos que dejen de serle útiles.
•	Seguridad de tipos: El CLR facilita la detección de errores de programación difíciles de localizar comprobando que toda conversión de tipos que se realice durante la ejecución de una aplicación .NET se haga de modo que los tipos origen y destino sean compatibles.
•	Aislamiento de procesos: El CLR asegura que desde código perteneciente a un determinado proceso no se pueda acceder a código o datos pertenecientes a otro, ni se permite acceder a posiciones arbitrarias de memoria.
•	Tratamiento de excepciones: En el CLR todo los errores que se puedan producir durante la ejecución de una aplicación se propagan de igual manera: mediante excepciones.
•	Soporte multihilo: El CLR es capaz de trabajar con aplicaciones divididas en múltiples hilos de ejecución que pueden ir evolucionando por separado en paralelo o intercalándose, según el número de procesadores de la máquina sobre la que se ejecuten. Las aplicaciones pueden lanzar nuevos hilos, destruirlos, suspenderlos por un tiempo o hasta que les llegue una notificación, enviarles notificaciones, sincronizarlos, etc.
•	Distribución transparente: El CLR ofrece la infraestructura necesaria para crear objetos remotos y acceder a ellos de manera completamente transparente a su localización real, tal y como si se encontrasen en la máquina que los utiliza.
•	Seguridad avanzada: El CLR proporciona mecanismos para restringir la ejecución de ciertos códigos o los permisos asignados a los mismos según su procedencia o el usuario que los ejecute.
Como se puede deducir de las características comentadas, el CLR lo que hace es gestionar la ejecución de las aplicaciones diseñadas para la plataforma .NET. Por esta razón, al código de estas aplicaciones se le suele llamar código gestionado, y al código no escrito para ser ejecutado directamente en la plataforma .NET se le suele llamar código no gestionado.
Podemos obtener más información en los siguientes enlaces:
•	Wikipedia
•	MSDN Microsoft
4.2.	C#
C#  (pronunciado si sharp en inglés) es un lenguaje de programación orientado a objetos desarrollado y estandarizado por Microsoft como parte de su plataforma .NET, que después fue aprobado como un estándar por la ECMA (ECMA-334) e ISO (ISO/IEC 23270). C# es uno de los lenguajes de programación diseñados para la infraestructura de lenguaje común.
Su sintaxis básica deriva de C/C++ y utiliza el modelo de objetos de la plataforma .NET, similar al de Java, aunque incluye mejoras derivadas de otros lenguajes.
El nombre C Sharp fue inspirado por la notación musical, donde '#' (sostenido, en inglés sharp) indica que la nota (C es la nota do en inglés) es un semitono más alta, sugiriendo que C# es superior a C/C++. Además, el signo '#' se compone de cuatro signos '+' pegados.2
Aunque C# forma parte de la plataforma .NET, ésta es una API, mientras que C# es un lenguaje de programación independiente diseñado para generar programas sobre dicha plataforma. Ya existe un compilador implementado que provee el marco Mono - DotGNU, el cual genera programas para distintas plataformas como Windows, Unix, Android, iOS, Windows Phone, Mac OS y GNU/Linux.
C# combina los mejores elementos de múltiples lenguajes de amplia difusión como C++, Java, Visual Basic o Delphi. De hecho, su creador Anders Heljsberg fue también el creador de muchos otros lenguajes y entornos como Turbo Pascal, Delphi o Visual J++. La idea principal detrás del lenguaje es combinar la potencia de lenguajes como C++ con la sencillez de lenguajes como Visual Basic, y que además la migración a este lenguaje por los programadores de C/C++/Java sea lo más inmediata posible.
El estándar ECMA-334 lista las siguientes metas en el diseño para C#:
•	Lenguaje de programación orientado a objetos simple, moderno y de propósito general.
•	Inclusión de principios de ingeniería de software tales como revisión estricta de los tipos de datos, revisión de límites de vectores, detección de intentos de usar variables no inicializadas, y recolección de basura automática.
•	Capacidad para desarrollar componentes de software que se puedan usar en ambientes distribuidos.
•	Portabilidad del código fuente.
•	Fácil migración del programador al nuevo lenguaje, especialmente para programadores familiarizados con C, C++ y Java.
•	Soporte para internacionalización.
•	Adecuación para escribir aplicaciones de cualquier tamaño: desde las más grandes y sofisticadas como sistemas operativos hasta las más pequeñas funciones.
•	Aplicaciones económicas en cuanto a memoria y procesado.
4.3.	Winforms
Windows Forms (o formularios Windows) es el nombre dado a la interfaz de programación de aplicación gráfica (GUI ) que se incluye como parte de Microsoft .NET Framework, que proporciona acceso a los elementos de la interfaz de Microsoft Windows nativas envolviendo la API de Windows existente en código administrado.
Una aplicación de Windows Forms es una aplicación orientada a eventos con el apoyo de Microsoft .NET Framework. A diferencia de un programa por lotes, que pasa la mayor parte de su tiempo simplemente esperando a que el usuario haga algo, como relleno en un cuadro de texto o haga clic en un botón.
El conjunto de clases de Windows Forms se encuentra físicamente dentro de la librería System.Windows.Forms.dll ubicada en el directorio donde está instalada la versión del .NET Framework.
Lógicamente, Windows Forms tiene la siguiente jerarquía en el Modelo de objetos del .NET Framework, tal como se muestra en la imagen.
Observación: Como se visualiza en la imagen, las clases pertenecientes al Namespace System.Windows.Forms heredan indirectamente de Object que es la clase base de la cual heredan todas las clases del .NET Framework.
Las clases del Namespace System.Windows.Forms se pueden clasificar en 2 grupos: objetos visuales y no visuales.
Los objetos visuales de Windows Forms se dividen en 4 categorías:
•	Control, UserControl y Form: La clase Control es la clase base que tiene la funcionalidad de todos los controles que se usan en un formulario (clase Form). Mientras que la clase User Control sirve para crear controles personalizados que están compuestos por otros controles Windows.
•	Controls: Se refiere a los controles Windows que al arrastrarse a un formulario se muestran en el diseñador de formularios de Visual Studio .NET, tales como controles de entrada de datos: TextBox y ComboBox, de salida de datos: Label y ListView, de comandos: Button y ToolBar, etc.
•	Componentes: Los componentes son clases similares a los controles pero que no heredan del Control y que al arrastrarse a un formulario no se ven en el diseñador de formularios sino en el diseñador de componentes de visual studio .NET, tales como componentes de información al usuario: ToolTip y ErrorProvider, componentes de menús: MainMenu y ContextMenu, componentes de ayuda: Help y HelpProvider.
•	Common Dialog Boxes: Los cuadros de diálogos comunes son objetos que al arrastrarse al formulario también se ubican en el Diseñador de Componentes de Visual Studio .NET, tales como diálogos de archivos: OpenFileDialog y SaveFIleDialog, diálogos de color: ColorDialog, diálogos de Fuentes: FontDialog y los diálogos de impresión: PrintDialog, PageSetupDialog y PrintPreviewDialog.
Existen 2 categorías de objetos no visuales en Windows Forms:
•	Objetos: Aplication, Clipboard, CurrencyManager, Cursor, Screen, etc.
•	Argumentos de Eventos: Heredan de System.EventArgs, tales como: KeyEventArgs, KeyPressEventArgs, MouseEventArgs, etc.
4.4.	Visual Studio 2010 - IDE
Microsoft Visual Studio es un entorno de desarrollo integrado (IDE ) de Microsoft . Se utiliza para desarrollar programas de ordenador para Microsoft Windows, así como sitios web, aplicaciones web y servicios web. Visual Studio utiliza plataformas de desarrollo de software de Microsoft, tales como API de Windows, Windows Forms, de Windows Presentation Foundation, Windows Communication Foundation, la tienda de Windows y Microsoft Silverlight. Se puede producir tanto en código nativo y código administrado.
Visual Studio incluye un editor de código de soporte IntelliSense (la finalización de código de componentes), así como la refactorización de código. El depurador integrado funciona tanto como un depurador a nivel de fuente como un depurador a nivel de máquina. Otras herramientas integradas incluyen un diseñador de formularios para la construcción de GUI aplicaciones, diseñador de páginas web, la clase de diseño y esquema de base de diseño. Permite la integración de plug-ins que mejoran la funcionalidad en casi todos los niveles, incluyendo la adición de soporte para el control de versiones de código (como Subversion o GIT) y la adición de nuevos conjuntos de herramientas como editores y diseñadores visuales para lenguajes específicos de dominio o conjuntos de herramientas para otros aspectos del ciclo de vida de desarrollo de software (como el Team Foundation Server).
Visual Studio es compatible con diferentes lenguajes de programación y permite la edición de código y el soporte de debug (en diversos grados) en casi cualquier lenguaje de programación, siempre que exista un servicio específico del lenguaje. Los lenguaje incorporados incluyen C, C++ y C++/CLI (a través de Visual C++), VB.NET (a través de Visual Basic.NET), C# (a través de Visual C#), y F# (a partir de Visual Studio 2010). El soporte para otros lenguajes como Python, Rubí, Node.js, y M entre otros está disponible a través de los servicios de lenguaje instalados por separado. También es compatible con XML/XSLT, HTML/XHTML, Javascript y CSS. Java (y J#) se apoyaron en el pasado.
En versiones anteriores a la 2015, Visual Studio estaba disponible de forma gratuita a los estudiantes a través del programa de Microsoft DreamSpark. A partir de Visual Studio 2015, Microsoft proporciona ediciones community con soporte de plugins, sin costo alguno para todos los usuarios.
4.5.	GIT y GitHub
Comenzaremos explicando que es un sistema de control de versiones y porque es necesario.
Se llama control de versiones a la gestión de los diversos cambios que se realizan sobre los elementos de algún producto o una configuración del mismo. Una versión, revisión o edición de un producto, es el estado en el que se encuentra el mismo en un momento dado de su desarrollo o modificación.
Aunque un sistema de control de versiones puede realizarse de forma manual, es muy aconsejable disponer de herramientas que faciliten esta gestión dando lugar a los llamados sistemas de control de versiones o VCS (del inglés Version Control System). Estos sistemas facilitan la administración de las distintas versiones de cada producto desarrollado, así como las posibles especializaciones realizadas (por ejemplo, para algún cliente específico). Ejemplos de este tipo de herramientas son entre otros: CVS, Subversion, SourceSafe, Git, Mercurial,o Team Foundation Server.
El control de versiones se realiza principalmente en la industria informática para controlar las distintas versiones del código fuente dando lugar a los sistemas de control de código fuente o SCM (siglas del inglés Source Code Management). Sin embargo, los mismos conceptos son aplicables a otros ámbitos como documentos, imágenes, sitios web, etc.
Un sistema de control de versiones debe proporcionar:

•	Mecanismo de almacenamiento de los elementos que deba gestionar (ej. archivos de texto, imágenes, documentación...).
•	Posibilidad de realizar cambios sobre los elementos almacenados (ej. modificaciones parciales, añadir, borrar, renombrar o mover elementos).
•	Registro histórico de las acciones realizadas con cada elemento o conjunto de elementos (normalmente pudiendo volver o extraer un estado anterior del producto).
Aunque no es estrictamente necesario, suele ser muy útil la generación de informes con los cambios introducidos entre dos versiones, informes de estado, marcado con nombre identificativo de la versión de un conjunto de ficheros, etc.
4.5.1.	Git
Como muchas de las grandes cosas en esta vida, Git comenzó con un poco de destrucción creativa y encendida polémica. El núcleo de Linux es un proyecto de software de código abierto con un alcance bastante grande. Durante la mayor parte del mantenimiento del núcleo de Linux (1991-2002), los cambios en el software se pasaron en forma de parches y archivos. En 2002, el proyecto del núcleo de Linux empezó a usar un DVCS propietario llamado BitKeeper.
En 2005, la relación entre la comunidad que desarrollaba el núcleo de Linux y la compañía que desarrollaba BitKeeper se vino abajo, y la herramienta dejó de ser ofrecida gratuitamente. Esto impulsó a la comunidad de desarrollo de Linux (y en particular a Linus Torvalds, el creador de Linux) a desarrollar su propia herramienta basada en algunas de las lecciones que aprendieron durante el uso de BitKeeper. Algunos de los objetivos del nuevo sistema fueron los siguientes:
•	Velocidad
•	Diseño sencillo
•	Fuerte apoyo al desarrollo no lineal (miles de ramas paralelas)
•	Completamente distribuido
•	Capaz de manejar grandes proyectos (como el núcleo de Linux) de manera eficiente (velocidad y tamaño de los datos)
Desde su nacimiento en 2005, Git ha evolucionado y madurado para ser fácil de usar y aún conservar estas cualidades iniciales. Es tremendamente rápido, muy eficiente con grandes proyectos, y tiene un increíble sistema de ramificación (branching) para desarrollo no lineal, además en la actualidad se ha convertido en un estándar de facto, sobre todo en el desarrollo de software libre.
4.5.2.	GitHub
GitHub es un alojamiento web para alojar proyectos utilizando el sistema de control de versiones Git. El código se almacena en repositorios de forma pública, aunque también se puede hacer de forma privada, creando una cuenta de pago.
GitHub proporciona además:
•	Wiki  para cada proyecto
•	Página web para cada proyecto
•	Gráfico para ver cómo los desarrolladores trabajan en sus repositorios y bifurcaciones del proyecto
•	Funcionalidades como si se tratase de una red social, como por ejemplo: seguidores;
•	Es bueno para trabajo colaborativo entre programadores.
•	Administración de Issues 
 
5.	Implementación 
5.1.	Metodología
Para el desarrollo del proyecto, se ha optado por usar metodologías agiles, dado que las metodologías tradicionales (Métrica 3, Cascada, en V) son muy rígidas frente a los cambios, se deben seguir unas políticas y normas muy estrictas, y obligan a ceñirse al análisis inicial del desarrollo.
Por el contrario las metodologías agiles (XP, SCRUM, Kanban) tienen una mayor flexibilidad ante los cambios, los procesos están menos ceñidos a normas y permiten una mayor respuesta al cambio, y dado que el proyecto queremos que nos sea lo más útil posible, necesitábamos tener una mayor libertar para ir adaptándolo y modificándolo conforme fuéramos avanzando en él.
Se ha partido de un análisis genérico, para a continuación ir realizando cada sección en ciclos más cortos en los cuales se parte de un análisis, se buscan cada una se las tareas a realizar, se ordenan y se van implementando, en caso de encontrarnos con vacíos o mejoras a implementar, se añaden a la lista de tareas, para realizarlas en el siguiente ciclo.
5.1.1.	Metodología mixta 
Dado que prácticamente todos los roles los hemos acaparado, no tenía mucho sentido seguir una metodología ágil al pie de la letra, ya que las reuniones de equipo (clientes, programadores, analistas) no tenían sentido, así que hemos acabado realizando una mezcla entre XP (extreme programing) y Agile.
5.1.2.	TDD
Aunque no hemos seguido una metodología totalmente TDD (Test-Driven Development) desarrollo guiado por pruebas, sí que hemos querido apoyarnos en los test unitarios, para poder realizar los procesos de refactorización teniendo mayor seguridad. 
5.2.	Programación orientada a objetos 

5.3.	Patrones de diseño 

5.4.	GUI

 
6.	Control de calidad y pruebas
Explicar el uso de pruebas unitarias, para cubrir el máximo posible de la funcionalidad de los objetos.
•	En la presentación, podría mostrar un ejemplo modificando el código para que fallen las pruebas, y que se vea de una forma más visual su utilidad.

Plasmar la cantidad de pruebas implementadas (ahora más de 150), y ver si podemos sacar un informe de cobertura.

Investigar que otro tipo de pruebas podemos realizar… 
•	Integración (creo que no tiene sentido en este trabajo)
•	de Interfaz (si fuera una web tendría más sentido, es una aplicación de escritorio que tiene 4 pantallas por así decir, no creo interesante el perder el tiempo intentándolo) 
•	de Funcionalidad, quizás podría preparar un par de ellas, lanzando un test y comprobando el resultado.
 
7.	Resultados y conclusiones

1-	Claramente el conector nativo funciona mucho mejor que por ODBC, además de que está preparado para multihilo, mientras que el conector ODBC ha demostrado ser indiferente a la ejecución en paralelo.
Con lo cual siempre será recomendable cambiar el conector ODBC por uno nativo si existe, ya que este además de ser más rápido, soportara mucho mejor la concurrencia.
2-	El uso de conexiones globales, es contraproducente por los bloqueos, demostrando que una sola conexión usada desde multiples hilos produce demasiados problemas.
Aunque la apertura y cierre de la conexión no es algo extremadamente caro, viendo los resultados, siempre será aconsejable reutilizar la conexión en el ciclo de la petición, sobre todo en aplicaciones Web, abrir la conexión una vez, realizar todas las consultas que sean necesarias para retornar la página al usuario y cerrarla siempre, tema muy importante, no dejarse conexiones huérfanas.

Exponer que ha quedado pendiente un tipo de prueba que sería el más interesante, ya que no ha dado tiempo, comparar dos bloques de sentencias distintas que retornan los mismos resultados, para ver qué construcción es más eficiente, para ello se debería guardar el resultado de cada una y comparar que efectivamente retornan los mismos datos.
Exponer también que ha quedado pendiente la realización de un asistente que generara las consultas mediante el uso de un pseudo lenguaje, o ayuda.
Aclarar que lo que ha quedado pendiente, no ha sido por desconocimiento sino por falta de tiempo ya que es un trabajo limitado a una cantidad de horas y que lo que ha quedado fuera pueden ser mejoras para implemente en el futuro, ya que el código es libre y de acceso público en github.
 
8.	Vocabulario 
 
 
Apache, 3
 
Java, 3
 
MySQL, 3
 
NoSQL, 3
 
ODBC, 3
Oracle, 3
ORM, 3
 
PHP, 3
 
SGBD, 3
SQL, 3
SQL Server, 3
 
Tomcat, 3
 

 
9.	Anexos
A.	Manual de usuario
 
10.	Referencias y bibliografía
•	.Net Framework -  https://msdn.microsoft.com/es-es/library/hh425099(v=vs.110).aspx
•	https://es.wikipedia.org/wiki/Microsoft_.NET
•	 C# - https://es.wikipedia.org/wiki/C_Sharp#cite_note-1 
•	Visual Studio - https://translate.googleusercontent.com/translate_c?depth=1&hl=es&ie=UTF8&prev=_t&rurl=translate.google.es&sl=en&tl=es&u=https://en.wikipedia.org/wiki/Microsoft_Visual_Studio&usg=ALkJrhg8wABD6-OAkGG5kpZYmuIh6GPCqA 
•	Extreme Programming Explained, Kent Beck
•	Clean Code: A Handbook of Agile Software Craftsmanship, Robert C. Martin
•	Design Patterns: Elements of Reusable Object-Oriented Software, Gang of Four
