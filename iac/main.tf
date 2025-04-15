provider "azurerm" {
  features {}
}

resource "azurerm_resource_group" "rg" {
  name     = "demo-copilot-04-rg"
  location = "East US"
}

resource "azurerm_container_app_environment" "env" {
  name                = "demo-copilot-04-env"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
}

resource "azurerm_container_app" "app" {
  name                = "demo-copilot-04-app"
  resource_group_name = azurerm_resource_group.rg.name
  container_app_environment_id = azurerm_container_app_environment.env.id
  revision_mode = "Single" # Single revision mode for the container app

  ingress {
    external_enabled = true
    target_port      = 80    
    traffic_weight {
      percentage = 100
      latest_revision = "true"
    }
  }

  template {
    container {
      name   = "hello-world"
      image  = "mcr.microsoft.com/azuredocs/aci-helloworld:latest"
        cpu    = "0.5"
        memory = "1.0Gi"
    }
  }
}
