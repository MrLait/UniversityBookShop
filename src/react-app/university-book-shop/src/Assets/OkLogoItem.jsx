import React from 'react';

const OkLogoItem = (props) => (
    <svg
        xmlns="http://www.w3.org/2000/svg"
        viewBox="0 0 24 24"
        width="24"
        height="24"
        {...props}
    >
        <g id="Outlined">
            <circle style={{ fill: 'none', stroke: '#000000', strokeWidth: 2, strokeMiterlimit: 10 }} cx="12" cy="12" r="9" />
            <polyline
                id="Done__x2014__Displayed_on_the_left_side_of_a_contextual_action_bar__x28_CAB_x29__to_allow_the_user_to_dismiss_it._5_"
                style={{ fill: 'none', stroke: '#000000', strokeWidth: 2, strokeMiterlimit: 10 }}
                points="17,9 10,16 7,13"
            />
        </g>
    </svg>
);

export default OkLogoItem;