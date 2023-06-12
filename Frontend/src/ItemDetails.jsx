import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import axios from "axios";
import "./styles.css";

function ItemDetails() {
  const { id } = useParams();
  const [item, setItem] = useState(null);

  useEffect(() => {
    fetchItemDetails();
  }, []);

  const fetchItemDetails = () => {
    axios
      .get(`/api/items/${id}`)
      .then((response) => {
        setItem(response.data);
      })
      .catch((error) => {
        console.error("Error fetching item details:", error);
      });
  };

  const updateItem = () => {
    // Implement the logic to update the item details using the API endpoint
    // You can use a form similar to the ItemForm component to collect the updated details
  };

  return (
    <div>
      <h1>Item Details</h1>
      {item ? (
        <div>
          <h3>{item.name}</h3>
          <p>{item.description}</p>
          {/* Display other item details */}
          <button onClick={updateItem}>Update</button>
        </div>
      ) : (
        <div>Loading...</div>
      )}
    </div>
  );
}

export default ItemDetails;
