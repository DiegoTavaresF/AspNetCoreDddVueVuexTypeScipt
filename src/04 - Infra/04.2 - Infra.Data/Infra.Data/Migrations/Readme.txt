Add-Migration "inicio" -Project "Ddd.Infra.Data" -Context ContextBase 
Update-Database -Project "Ddd.Infra.Data" -Context ContextBase 

Add-Migration "inicio" -Project "Ddd.Infra.CrossCutting.Identity" -Context ApplicationDbContext 
Update-Database -Project "Ddd.Infra.CrossCutting.Identity" -Context ApplicationDbContext 

