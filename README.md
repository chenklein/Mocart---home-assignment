App Description:

* On app start, a random selection of 1-3 products will appear on a shelf, displaying their name, price, and description.
* To edit the name and price, click the text field, make your modifications, and then click the product's "Modify" button to save changes.
* To restart the app, click the "Restart" button located in the bottom-right corner.
  


Structure Overview:

Data Storage:
ProductData (ProductData.cs): This ScriptableObject stores individual product data (ID, name, description, price, and 3D model).
ProductDataContainer (ProductDataContainer.cs): This ScriptableObject holds a list of ProductData objects, serving as a centralized data container for product information.

Data Handling:
DataHandler (DataHandler.cs): This component fetches product data from an external API, deserializes it, and passes it to the AppManager for display and storage. It uses UnityWebRequest for asynchronous data fetching and handles errors by displaying them in a user log.
App Logic:

AppManager (AppManager.cs): 
Manages the initialization and display of products. On app start, it displays products from the data source (either pre-existing or newly fetched from the server) and instantiates the 3D model and UI elements. It also manages scene restarting functionality.
ProductProfile (ProductProfile.cs): Controls the display and modification of individual product data in the UI. Users can edit product details, which then updates the underlying ProductData.

Design Decisions

Use of Scriptable Objects:
Storing product information in ScriptableObjects (e.g., ProductData, ProductDataContainer) is a solid choice for Unity, as it allows for easy data persistence, editing within the Unity Editor, and smooth integration with other components. This approach reduces the need for constant API calls by storing data locally.

Data Management:
The DataHandler fetches JSON data and calls AppManager to populate products. Separating data handling from UI management (handled in AppManager) improves maintainability, making it easy to update or modify data sources in the future.

UI Control:
The ProductProfile component provides a clear, user-friendly way to edit product data directly from the UI. Using UI elements like Text fields for display and editable text boxes for modifications aligns with a typical Unity UI setup, allowing intuitive interaction.



Run Project Locally: 

To run a Unity WebGL project locally, you need to set up a local server because WebGL content typically requires an HTTP server to load resources properly due to browser security restrictions. Here are a few methods you can use:

1. Using Unity’s Built-in Web Server
After building your WebGL project in Unity, open the build folder.
Double-click on the index.html file. In some cases, Unity’s built-in server will start and host the project. However, this might not work consistently on all browsers due to security settings.

2. Using Python HTTP Server
Navigate to your WebGL build folder in the command line.
If you have Python installed, you can start a simple HTTP server with one of the following commands:

For Python 3.x:
python -m http.server

For Python 2.x:
python -m SimpleHTTPServer

This will start a server at http://localhost:8000. Open your browser and go to that address to run your WebGL project.

3. Using Node.js and http-server
First, install Node.js if you haven’t already.
Install the http-server package globally by running:

npm install -g http-server

Navigate to your WebGL build folder and start the server with:

http-server

By default, this will start the server at http://localhost:8080.

4. Using a Browser Extension (Temporary Solution)
For quick testing, some browser extensions allow you to disable local file restrictions.
Search for “Disable Web Security” or “Allow CORS” extensions, but keep in mind this approach is not secure and should only be used for temporary, local testing.

5. Using Visual Studio Code with Live Server Extension
If you’re using VS Code, install the Live Server extension.
Right-click on index.html in the WebGL build folder and select “Open with Live Server.”
This will start a server and open the project in your browser.



