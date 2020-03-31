import React from "react";
import { Text, RichText, Image, Link } from "@sitecore-jss/sitecore-jss-react";

const ProductRecommendationListItem = ({ fields }) => {
  return (
    <div className="productRecommendationList-item">
      <div className="productRecommendationList-item-inner">
          <div className="productRecommendationList-item-image">
            <img src={fields.SummaryImageUrl}></img>
          </div>
          <div className="productRecommendationList-item-body">           
            <h5 className="productRecommendationList-item-title">
              {fields.DisplayName}
            </h5>
            <p>
              {fields.ProductId}
            </p>
            <div className="productRecommendationList-item-desc">
              <p>{fields.Description}</p>
            </div>
            <h5 className="productRecommendationList-item-title">
              {fields.ListPriceWithCurrency}
            </h5>
            <h4 className="productRecommendationList-item-title">
              {fields.StockStatusLabel}
            </h4>
          </div>
      </div>
    </div>
  );
};

export default ProductRecommendationListItem;
