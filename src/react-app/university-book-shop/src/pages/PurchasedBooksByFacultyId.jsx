// @ts-nocheck
import React, { useEffect, useState } from 'react'
import PurchasedBooksList from '../components/screens/PurchasedBook/PurchasedBooksList'
import { useParams } from 'react-router-dom'
import styles from './PurchasedBooksByFacultyId.module.css'

const PurchasedBooksByFacultyId = () => {
    const facultyId = parseInt(useParams().faculty_id || 0);
    return (
        <>
            <PurchasedBooksList facultyId={facultyId} />
        </>
    )
}
export default PurchasedBooksByFacultyId