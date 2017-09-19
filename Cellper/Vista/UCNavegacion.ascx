<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCNavegacion.ascx.cs" Inherits="Cellper.Vista.UCNavegacion" %>

<!DOCTYPE HTML>

<html>

	<body>

		<!-- Wrapper -->
			<div id="wrapper">

				<!-- Main -->


				<!-- Sidebar -->
					<div id="sidebar">
						<div class="inner">

							<!-- Search -->


							<!-- Menu -->
								<nav id="menu">
									<header class="major">
										<h2>Menu</h2>
									</header>
									<ul>
										<li><a href="Principal.aspx">Inicio</a></li>
										<li>
											<span class="opener">Servicio Técnico</span>
											<ul>
												<li><a href="RecepcionEquipo.aspx">Recepción de equipos</a></li>
												<li><a href="ColaDeEquipos.aspx">Cola de equipos Pendientes</a></li>
											</ul>
										</li>

										<li>
											<span class="opener">Consultas</span>
											<ul>
												<li><a href="ColaReparacionEquipo.aspx">Cola de Equipos por Entregar</a></li>
                                                <li><a href="EquiposEntregados.aspx">Equipos Entregados</a></li>
											</ul>
										</li>
										<li>
											<span class="opener">Opciones especiales</span>
											<ul>
                                                <li><a href="Inventario.aspx">Inventario</a></li>
												<li><a href="MarcaEquipo.aspx">Marca equipo</a></li>
                                                <li><a href="ModeloEquipo.aspx">Modelo equipo</a></li>
                                                <li><a href="FallaEquipo.aspx">Fallas</a></li>
                                                <li><a href="Tecnico.aspx">Técnicos</a></li>
											</ul>
										</li>
										<li>
											<span class="opener">Seguridad</span>
											<ul>
                                                <li><a href="Seguridad.aspx">Agregar usuario</a></li>
											</ul>
										</li>
                                        <li><a href="Logout.aspx">Salir</a></li>
									</ul>
								</nav>

							<!-- Section -->


							<!-- Section -->


							<!-- Footer -->
								<footer id="footer">
									<p class="copyright">&copy; Cellper. Todos los derechos reservados.</p>
								</footer>

						</div>
					</div>

			</div>

		<!-- Scripts -->
 

	</body>
</html>