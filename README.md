# EmployeeApp-webapi
#steps
 ===> Download the zip file of the project and extract in the required local repo
 ===> open the visual studio 
 ===> go to file options
 ===> choose Open this existing project
 ===> Build the Project
 ===> And host this project in IIS
 ===> use this api methods in Api controller 

Following are 3 simple steps to create an New HTTP service that returns non-SOAP based data:

         1.Create Web API Project
         2.Prepare domain Model
         3.Adding Controller class

#1 Create Web API Project
  => Open Visual Studio and create "New Project", i.e., File -> New Project.
  => Choose "ASP.NET MVC 4 Web Application" template and name project as "FirstWebAPIService".
  => When you click "OK" button, a new window will appear for selecting a sub-template. Actually for ASP.NET MVC 4 Web Application, we have multiple sub-options, i.e., Empty, Internet Application, Web API, etc.
  => Choose "Web API" and simply press "OK" button.
  => A default ASP.NET MVC 4 Web API template project is created. As it is an MVC application template, you will easily find "Model", "View" and "Controller" folders inside it.

#2. Preparing Domain Model
  => Now in a second step, we need to prepare the model.
  =>Right click on the "Model" folder and choose "Class" under "Add" from the context menu as shown in the figure.
Name the class as "Product.cs".

Here is the code for Product class:

Copy Code
public class Product
{
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public string ProductCategory { get; set; }
    public int Price { get; set; }
}

#3. Adding Controller class

  =>Controller class plays an important role, because request coming from client hits the controller first. Then the controller decides which model to use to serve the incoming request. So, in order to add a controller:

  =>Right click on the "Controller" folder and choose "Controller" under "Add" from the context menu as shown in figure.
Name the controller as "ProductsController".

  =>Click the "Add" button, a new controller class will be added.
In order to make things simple, we will load the model with data inside this controller instead of loading it from database. Following is the code for controller class.

Copy Code
public class ProductsController : ApiController
{
        Product[] products = new Product[]
         {
             new Product { ProductID = 1, ProductName = "Product 1", 
                           ProductCategory= "Category 1", Price = 120 },
             new Product { ProductID = 2, ProductName = "Product 2", 
                           ProductCategory= "Category 1", Price = 100 },
             new Product { ProductID = 3, ProductName = "Product 3", 
                           ProductCategory= "Category 2", Price = 150 },
             new Product { ProductID = 4, ProductName = "Product 4", 
                           ProductCategory= "Category 3", Price = 90 }
         };
        public IEnumerable<Product> GetProducts()
        {
            return products;
        }
}
  =>Don't forget to add "using FirstWebAPIService.Models;" at the top of the controller class.



   Refer this following link to create New Project https://www.codeproject.com/Articles/660719/Simple-Steps-to-Create-Your-First-ASP-NET-Web-API
