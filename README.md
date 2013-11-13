OctoFX is a sample application, built to demonstrate how a multi-tier application can be deployed using Octopus Deploy. 



## Domain overview

OctoFX Ltd is a fictitious London-based online foreign exchange company. Retail customers and businesses can register an account with OctoFX, and use the platform to trade currencies. 

Customers interact with the OctoFX platform by logging onto the site and requesting a quote. A **quote request** looks like this:

 * I have: **1000 USD**
 * I want: **GBP**

The system gets the current exchange rate for the **currency pair** (USD/GBP) and returns a quote:

 * Sell: **1000 USD**
 * Buy: **629.25 GBP**
 * Expires: *[expiry time]*

Behind the scenes, an army of **dealers** working for OctoFX are busily trading currency pairs when they see good rates. While the market rate offerred for an given currency pair is always changing, the rates offered to OctoFX customers are determined by the dealers (who make their profit by taking a few basis points for themselves), so the rates used for quotes change only every 5 minutes or so. The quote is therefore valid for only a few minutes. 

If the customer is happy with the quote, and if the quote hasn't expired, they can commit to a trade. This trade is called a **deal**. When booking the deal, the customer also nominates a bank account that will receive the converted funds (in this case, the GBP), which is called a **beneficiary account**. It might be another account held by the customer, or perhaps by their friends or family overseas. 

 * Customer sells: **1000 USD**
 * Customer buys: **629.25 GBP**
 * Entered: *[date/time]*
 * Status: *Awaiting funds*
 * Nominated beneficiary: *[bank account details]*

At this stage, the customer has committed to a deal, but no money has changed hands. The deal has a status of *Awaiting funds*. The customer has to first transfer 1000 USD to a USD bank account held by OctoFX (we call them **clearing accounts**). When OctoFX receives the funds, the GBP is then deposited to the nominated account on the deal, and the deal has a status of **Settled**. 

## Solution overview

The application consists of four major components:

 - **Trading Website**  
   A customer-facing ASP.NET MVC website, where customers trade currencies. Customers can register, login, manage their beneficiary account details, get quotes, and book deals. 
 - **Dealer Portal**  
   An ASP.NET MVC website used by the dealers to adjust the rates offered to customers. 
 - **Deal Settlement Service**  
   A .NET Windows Service that simulates the bank reconcilation and deal settlement process. It checks whether the OctoFX clearing accounts have received funds for any pending deals, and then initiates the transfer when deals are ready to be settled.

A SQL Server database underpins the system. 

## Development process

The OctoFX development team are forward-thinking and always looking to embrace good development practices. They realize that to compete in the cut-throat world of online FX trading, they need to be able to iterate and deploy new changes quickly, with low risk. 

The delivery pipeline looks something like this:

 1. Developers commit code to a Git repository
 2. A build server compiles the code and runs unit tests
 3. The application is deployed to a *Automated Test* environment
 4. A suite of automated web tests are run against the application deployed to the Test site
 5. The application is deployed to a *UAT* environment, for stakeholders to see new changes
 6. When the various stakeholders are happy, the application is promoted to the **Production** environment

