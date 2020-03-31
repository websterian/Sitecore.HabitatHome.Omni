import React, { Component } from "react";
import { getRawFieldValue } from "../../utils";
import { Text } from '@sitecore-jss/sitecore-jss-react';
import SelectFormField from '../SelectFormField';
import { getAll, StoresCount } from "../../services/StoreService";

class StoreSelector extends Component {
  state = {
    stores: [],
    loading: true,
    value: ""
  };

  constructor(props) {
    super(props);
    this.handleChange = this.handleChange.bind(this);
  }

  componentDidMount() {
    getAll()
      .then(response => {
        this.setState({ stores: response.data });
        this.setState({ loading: false });
      })
      .catch(error => {
        console.error(error);
      });
  }

  handleChange(event) {
    this.setState({ value: event.target.value });
    //this.props.onChange(event);
  }

  render() {
    const { fields } = this.props;
    const { stores, loading } = this.state;

    if (stores.length <= 0) {
      return null;
    }

    const selectorName = getRawFieldValue(fields.storeSelectorName);
    const selectorTitle = getRawFieldValue(fields.storeSelectorTitle);

    return (
      <div className="field">
        {selectorTitle}
        <select
          name={selectorName}
          value={this.state.value}
          onChange={this.handleChange}
        >
          <option value="" disabled>
            Shop 
          </option>
          {stores.map((option, index) => {
            return (
              <option key={option.Id} value={option.Name}>
                {option.Name}
              </option>
            );
          })}
        </select>
      </div>
    );
  }
}

export default StoreSelector;
