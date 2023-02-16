import React from "react";
import { App } from '../app/App';
import renderer from 'react-test-renderer';

describe('<App />', () => {
    it("matches the snapshot", () => {
        const tree = renderer.create(<App/>).toJSON();

        expect(tree).toMatchSnapshot();
    })
})