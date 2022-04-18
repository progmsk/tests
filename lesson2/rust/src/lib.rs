pub fn quicksort(slice: &mut [i32]) {
    if slice.len() < 2 {
        return;
    }

    let pivot = slice[0];
    let index = partition(slice, pivot);

    let (left, right) = slice.split_at_mut(index + 1);

    quicksort(left);
    quicksort(right);
}

#[test]
fn quicksort_132_makes_123() {
    let mut array = vec![1, 3, 2];

    quicksort(&mut array);

    assert_eq!(vec![1, 2, 3], array);
}

#[test]
fn quicksort_revert_unordered_array_with_2_item() {
    let mut array = vec![2, 1];

    quicksort(&mut array);

    assert_eq!(vec![1, 2], array);
}

#[test]
fn quicksort_keeps_ordered_array_with_2_item() {
    let mut array = vec![1, 2];

    quicksort(&mut array);

    assert_eq!(vec![1, 2], array);
}

#[test]
fn quicksort_keeps_array_with_1_item() {
    let mut array = vec![1];

    quicksort(&mut array);

    assert_eq!(vec![1], array);
}

#[test]
fn quicksort_keeps_empty_array() {
    let mut array = Vec::<i32>::new();

    quicksort(&mut array);

    assert_eq!(Vec::<i32>::new(), array);
}

fn partition(slice: &mut [i32], pivot: i32) -> usize {
    let mut left = 0;
    let mut right = slice.len() - 1;

    while try_step_partition(slice, &mut left, &mut right, pivot) { }

    left
}

#[test]
fn partitioning_with_4563012_makes_2103654() {
    let pivot = 3;
    let mut array = vec![4, 5, 6, pivot, 0, 1, 2];

    partition(&mut array, pivot);

    assert_eq!(vec![2, 1, 0, pivot, 6, 5, 4], array);
}

#[test]
fn partitioning_with_4563012_stops_on_pivot3() {
    let pivot = 3;
    let mut array = vec![4, 5, 6, pivot, 0, 1, 2];

    let index = partition(&mut array, pivot);

    assert_eq!(3, index);
}

#[test]
fn partitioning_with_ordered_data_does_nothing() {
    let pivot = 4;
    let mut array = vec![0, 1, 2, 3, pivot, 5, 6, 7];

    partition(&mut array, pivot);

    assert_eq!(vec![0, 1, 2, 3, pivot, 5, 6, 7], array);
}

#[test]
fn partitioning_with_ordered_data_stops_on_pivot() {
    let pivot = 4;
    let mut array = vec![0, 1, 2, 3, pivot, 5, 6, 7];

    let index = partition(&mut array, pivot);

    assert_eq!(4, index);
}

fn try_step_partition(slice: &mut [i32], left: &mut usize, right: &mut usize, pivot: i32) -> bool {
    *left = find_next_left(slice, *left, pivot);
    *right = find_next_right(slice, *right, pivot);

    if !try_swap_items(slice, *left, *right) {
        return false;
    }

    *left += 1;
    *right -= 1;

    *left < *right
}

#[test]
fn trying_step_partition_keeps_items_if_left_less_than_right() {
    let pivot = 2;
    let mut array = vec![0, 1, pivot, 3, 4];
    let mut left = 1;
    let mut right = 3;

    assert!(!try_step_partition(&mut array, &mut left, &mut right, pivot));

    assert_eq!(vec![0, 1, pivot, 3, 4], array);
    assert_eq!(2, left);
    assert_eq!(2, right);
}

#[test]
fn trying_step_partition_swaps_items_if_left_great_than_right() {
    let pivot = 2;
    let mut array = vec![4, 1, pivot, 3, 0];
    let mut left = 0;
    let mut right = 4;

    assert!(try_step_partition(&mut array, &mut left, &mut right, pivot));

    assert_eq!(vec![0, 1, pivot, 3, 4], array);
    assert_eq!(1, left);
    assert_eq!(3, right);
}

fn try_swap_items(slice: &mut [i32], left: usize, right: usize) -> bool {
    if left < right {
        slice.swap(left, right);

        return true;
    }

    false
}

#[test]
fn trying_swap_returns_false_if_left_equals_to_right() {
    let mut array = vec![0, 1, 2, 3, 4, 5];
    let left = 3;
    let right = 3;

    assert!(!try_swap_items(&mut array, left, right));
}

#[test]
fn trying_swap_returns_true_if_left_less_than_right() {
    let mut array = vec![0, 1, 4, 3, 2, 5];
    let left = 2;
    let right = 4;

    assert!(try_swap_items(&mut array, left, right));
}

#[test]
fn trying_swap_swaps_items_if_left_less_than_right() {
    let mut array = vec![0, 1, 4, 3, 2, 5];
    let left = 2;
    let right = 4;

    try_swap_items(&mut array, left, right);

    assert_eq!(2, array[2]);
    assert_eq!(4, array[4]);
}

fn find_next_right(slice: &[i32], right: usize, pivot: i32) -> usize {
    let mut i = right;

    while slice[i] > pivot {
        i -= 1
    }

    i
}

fn find_next_left(slice: &[i32], left: usize, pivot: i32) -> usize {
    let mut i = left;

    while slice[i] < pivot {
        i += 1
    }

    i
}

#[test]
fn finding_next_left_index_stop_on_pivot() {
    let pivot = 3;
    let array = vec![0, 1, 2, pivot, 4, 5];
    let mut left = 3;

    left = find_next_left(&array, left, pivot);

    assert_eq!(3, left);
}

#[test]
fn finding_next_left_index_stop_on_item_greater_that_pivot() {
    let pivot = 3;
    let array = vec![0, 1, 4, pivot, 2, 5];
    let mut left = 2;

    left = find_next_left(&array, left, pivot);

    assert_eq!(2, left);
}

#[test]
fn finding_next_left_index_skip_items_less_that_pivot() {
    let pivot = 3;
    let array = vec![0, 1, 2, pivot, 4, 5];
    let mut left = 1;

    left = find_next_left(&array, left, pivot);

    assert_eq!(3, left);
}
