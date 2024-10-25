
Question 2:  
A new category was created called PEP (politically exposed person). Also, a new bool property IsPoliticallyExposed was created in the ITrade interface. A trade shall be categorized as PEP if IsPoliticallyExposed is true. Describe in at most 1 paragraph what you must do in your design to account for this new category.  

---

Answer:  
Create a new method inside TradeFact that checks whether the category inside the string is true. Add the condition to create a new FactCreationStrat, inheriting from it's interface which contains all the logic on building the trade object. Which then creates a new child class from iTrades that encapsulates whatever logic one might want to implement.