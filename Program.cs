using Microsoft.Data.Sqlite; 
 using A.Database; 
 using A.Repositories; 
 using A.Models; 


 var modelName = args[0];
 var modelAction = args[1];

 var databaseConfig = new DatabaseConfig();
 new DatabaseSetup(databaseConfig);

  if(modelName == "Product") 
 {
     var productRepository = new ProductRepository(databaseConfig); 
  
     if(modelAction == "List") 
     { 
         Console.WriteLine("Product List"); 
          
         foreach (var computer in productRepository.GetAll()) 
         { 
             Console.WriteLine("{0}, {1}, {2}, {3}", product.Id, product.Name, product.Price, productRepository.Active); 
         } 
     } 
 }
    

      if(modelAction == "New") 
     { 
         Console.WriteLine("Product New"); 
         var id = Convert.ToInt32(args[2]); 
         var name = args[3]; 
         var price = args[4]; 
         var active = args[5];
  
         var computer = new Product(id, name, price, active); 
         ProductRepository.Save(product); 
     } 

      if(modelAction == "Show") 
     {
          Console.WriteLine("Product Show"); 
         var id = Convert.ToInt32(args[2]); 
          
         if(ProductRepository.ExistsById(id)) 
         { 
             var product = ProductRepository.GetById(id); 
             Console.WriteLine("{0},{1},{2},{3}", product.Id, product.Name, product.price, product.active); 
         } 

         else  
         { 
             Console.WriteLine($"O produto {id} não existe!"); 
         } 
     }

          if(modelAction == "Update") 
     { 
         Console.WriteLine("Product Update"); 
         var id = Convert.ToInt32(args[2]); 
         var name = args[3]; 
         var price = args[4]; 
         var active = args[5];
  
         if(productRepository.ExistsById(id)) 
         { 
             var computer = new product(id, name, price, active); 
             ProductRepository.Update(computer); 
             Console.WriteLine("{0},{1},{2},{3}", product.Id, product.Name, product.Price, ProductRepository.Active); 
         } 
         else  
         { 
             Console.WriteLine($"O produto {id} não existe!"); 
         } 
     } 

      if(modelAction == "Delete") 
     { 
         Console.WriteLine("Product Delete"); 
         var id = Convert.ToInt32(args[2]); 
          
         if(ProductRepository.ExistsById(id)) 
         { 
             ProductRepository.Delete(id); 
             Console.WriteLine("Product {0}", id); 
         } 
         else  
         { 
             Console.WriteLine($"O produto {id} não existe!"); 
         } 
     } 
 } 
  
    
  


