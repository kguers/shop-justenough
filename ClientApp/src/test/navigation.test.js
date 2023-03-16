import React from 'react';
import { shallow } from 'enzyme';
import { Navigation } from '../components/navigation/navigation';

describe('Navigation', () => {
  let wrapper;
  
  beforeEach(() => {
    wrapper = shallow(<Navigation />);
  });

  it('renders a logo image', () => {
    const logo = wrapper.find('.logo-img');
    expect(logo).toHaveLength(1);
  });

  it("toggles the sign in icon on hover", () => { 
    const button = wrapper.find(".navRightButtons").at(0);

    // Initial state
    expect(wrapper.find("FontAwesomeIcon").at(0).prop("data-test")).toBe("rightToBracket");

    // Simulate hover event
    button.simulate("mouseenter");

    // Updated state
    expect(wrapper.find("FontAwesomeIcon").at(0).prop("data-test")).toBe("personRunning");

    // Simulate hover out event
    button.simulate("mouseleave");

    // Back to initial state
    expect(wrapper.find("FontAwesomeIcon").at(0).prop("data-test")).toBe("rightToBracket");

    // Restore the original useState function
  });

  it('renders a search bar', () => {
    const searchBar = wrapper.find('.bar');
    expect(searchBar).toHaveLength(1);
  });

  it('renders a cart icon', () => {
    const cartIcon = wrapper.find('.navRightButtons').at(1);
    expect(cartIcon).toHaveLength(1);
  });
});
