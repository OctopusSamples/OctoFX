
## ARM templates

We have created a few ARM templates for use with OctoFX:

 - **vmss_register_tentacle_and_install_chocolatey.json**  
   A Virtual Machine Scale Set template which will attempt to install and register a listening tentacle on each VM that is spun up. It will open up port 10933.
   Optionally it will install any applications specified using chocolatey.
 - **vmss_register_tentacle_and_install_chocolatey_autoscale.json**  
   As the first Scale Set template, but with an autoscale setting to scale-out when avg CPU goes above 50% and scale-in when avg CPU goes below 30%