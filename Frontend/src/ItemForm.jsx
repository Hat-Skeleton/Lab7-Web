import React, { useState } from "react";
import axios from "axios";
import "./styles.css";

function ItemForm() {
  const [name, setName] = useState("");
  const [description, setDescription] = useState("");

  const handleSubmit = (e) => {
    e.preventDefault();
    const newItem = { name, description };

    axios
      .post("/api/items", newItem)
      .then((response) => {
        console.log("Item created successfully:", response.data);
        // Handle success, e.g., show a success message or navigate to another page
      })
      .catch((error) => {
        console.error("Error creating item:", error);
      });
  };

  return (
    <div>
      <h1>Item Form</h1>
      <form onSubmit={handleSubmit}>
        <label>
          Name:
          <input
            type="text"
            value={name}
            onChange={(e) => setName(e.target.value)}
          />
        </label>
        <br />
        <label>
          Description:
          <textarea
            value={description}
            onChange={(e) => setDescription(e.target.value)}
          />
        </label>
        <br />
        <button type="submit">Create Item</button>
      </form>
    </div>
  );
}

export default ItemForm;
